<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmStaffAttandence.aspx.cs"
    Inherits="iKandi.Web.Internal.Leave.frmStaffAttandence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
  
    <script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script>  
      <script type="text/javascript" src="../../js/facebox.js"></script>
    <script src="../../CommonJquery/JqueryLibrary/form.js" type="text/javascript"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    
     <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />

   
    <script src="../../js/Calender_new.js" type="text/javascript"></script>
  <%--<script src="../../js/service.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>--%>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <style type="text/css">
        body
        {
            font-family:Verdana;
        }
        .center-table table
        {
            margin: 0px auto;
        }
        .item_list2
        {
            margin-right: auto;
        }
        .top-head-bar td
        {
            border: none;
        }
        input type["text"]
        {
            text-transform: capitalize;
            width: 100%;
            padding: 0;
            height: 19px;
            position: relative;
           
            border: 1px solid #cdcdcd;
            border-color: rgba(0,0,0,.15);
            background-color: white;
            font-size: 11px;
        }
        td
        {
            text-transform: capitalize;
        }
        
        .ddl
        {
            border: 2px solid #7d6754;
            border-radius: 5px;
            padding: 3px;
            -webkit-appearance: none;
            background-image: url('Images/Arrowhead-Down-01.png');
            background-position: 88px;
            background-repeat: no-repeat;
            text-indent: 0.01px; /*In Firefox*/
            text-overflow: ''; /*In Firefox*/
        }
        #spinner
        {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(../../App_Themes/ikandi/images1/loading128.gif) 50% 50% no-repeat #EBF1FA;
        }
        .errorred
        {
            border: 2px solid red;
        }
        input[type=text]
        {
            text-align: center;
            font-weight: bold;
            
        }
      
        .myTextarea
        {
            display: block;
            width: 100%;
            height: 25px;
            text-transform: capitalize;
           text-align: left;
           color: #545050;
           font-family:Verdana;
        }
        
        
        #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        
        
        .hide_me
        {
            visibility: hidden;
        }
        .main-heading
        {
            font-size: 18px;
            border-bottom: 1px solid #d6d6d6;
            padding-bottom: 10PX;
            margin-bottom: 10PX;
            font-family: lucida sans unicode !important;
        }
        .rotate
        {
            color: #000;
            display: block; /*Firefox*/
            -moz-transform: rotate(-90deg); /*Safari*/
            -webkit-transform: rotate(-90deg); /*Opera*/
            -o-transform: rotate(-90deg);
            -ms-transform: rotate(-90deg); /* ie*/
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            color: #405d9a;
            font-weight: bold;
            
            font-family: arial;
           
        }
        .rotate2
        {
            color: #000;
            display: block;
            color: #405d9a;
            font-weight: bold;
            
            font-family: arial;
            padding: 0px;
        }
        .IMageProfile
        {
            padding:0px !important;
            width:59px;
        }
         .IMageProfile img
         {
            
             height:30px;
         }
         .item_list2 TD
         {
             padding:0px;
         }
         .item_list2 th
         {
             padding:0px;
         }
         .hiddencol
          {
            display: none;
          }
         .AddClass_Table th
         {
             padding:3px 0px;
         }
         .IMageProfile img 
         {
             width:95%;
         }
         .go {
            font-weight: 500;
            padding: 3px 5px;
            border-radius: 3px;
            float:right;
        }
        .go:hover {
            font-weight: 500;
            padding: 3px 5px;
            border-radius: 3px;
        }
         #sb-wrapper {
    background: #fff;
    padding: 10px 10px;
}
    </style>
    <div id="spinner">
    </div>  
    <script type="text/javascript">
        // 

        function GetdatePreDate() {

            debugger;
            var SelectedDate = $("#txtattendencedate").val();
            var Day = SelectedDate.split("/")[0];
            var Month = SelectedDate.split("/")[1];
            var Year = SelectedDate.split("/")[2];
            var currentTime_sele = new Date(Month + "/" + Day + "/" + Year)


            //  var currentDate = new Date(new Date().getTime());
            var currentDate = new Date();
            var day = currentDate.getDate()
            var month = currentDate.getMonth() + 1
            var year = currentDate.getFullYear()
            var todayss = new Date(month + "/" + day + "/" + year)
            //Currentdate_selesss(day + "/" + month + "/" + year);


            var selectdates_ = new Date(currentTime_sele);

            var todaydate = new Date(selectdates_);
            var CurrentDateseke = new Date(todayss);

            if (todaydate < CurrentDateseke) {
                return 'yesterday'
            }
            else {
                return 'today'
            }
        }
        $(document).ready(function () {
            //alert(GetdatePreDate());
            ShowImagePreview();
            $('.groupOfTexbox').on('input', function () {
                this.value = this.value.match(/^\d+\.?\d{0,1}/);
                //                $(".th").datepicker({ dateFormat: 'dd MMM yy (ddd)' });
                $(".th2").datepicker({ dateFormat: 'dd/mm/yyyy' });

                //                pageLoad();

                //                $(".tm").loop(function (element, index, set) {
                //                    alert(element.val());
                //                });

            });

            ////            $("#btnSubmit").click(function () {
            ////                var msg = "";
            ////                $("[name*=ddlstatus]").each(function (i, item) {
            ////                    //  debugger;
            ////                    if (item.selectedIndex == 0 ) {
            ////                        if ($(item).closest("tr").find("input[name*=txtintime]").val() == "" || $(item).closest("tr").find("input[name*=txtouttime]").val() == "" ||
            ////                        $(item).closest("tr").find("input[name*=txtintime_mm]").val() == "" || $(item).closest("tr").find("input[name*=txtoutfrom_mm]").val() == "") {
            ////                            msg = msg + "Please provide In time and out time for " + $(item).closest("tr").find(".h3").html() + "\n";
            ////                            //debugger;
            ////                            $(item).closest("tr").find(".error").addClass('errorred');
            ////                        }
            ////                    }
            ////                });
            ////                if (msg != "") {
            ////                    // alert(msg);                    
            ////                    error = msg;
            ////                    return false;
            ////                }
            ////            });
        });
        function checkhh(thiss) {
            //alert(thiss.id);
            if (thiss.value == "") {
                $('#' + thiss.id.substr(0, GetID(elem.id)) + "diverror").addClass('errorred');
            }
            else {
                $('#' + thiss.id.substr(0, GetID(elem.id)) + "diverror").removeClass('errorred');
                var val = Math.abs(parseInt(thiss.value, 10) || 1);
                thiss.value = val >= 25 ? 24 : val;
            }
        }
        function checkMM(thisn) {
            if (thisn.value == "") {
                $('#' + thisn.id.substr(0, GetID(elem.id)) + "diverror").addClass('errorred');
            }
            else {
                $('#' + thisn.id.substr(0, GetID(elem.id)) + "diverror").removeClass('errorred');
                if (thisn.value == "0" || thisn.value == "00") {
                    thisn.value = "00";
                }
                else {
                    var val = Math.abs(parseInt(thisn.value, 10) || 1);
                    thisn.value = val >= 59 ? 59 : val;
                }
            }
        }
        function minmax(value, min, max) {
            // debugger;
            if (parseInt(value) < min || isNaN(parseInt(value)))
                return "";
            else if (parseInt(value) > max)
                return "";
            else return value;
        }
        function Trigger() {
            $("#btnSubmit").click();
        }
        function isNumber(evt, element) {

            var charCode = (evt.which) ? evt.which : event.keyCode

            if (
            (charCode != 45 || $(element).val().indexOf('-') != -1) &&
            (charCode != 46 || $(element).val().indexOf('.') != -1) &&
            (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        $(function () {

            //            $(".th2").datepicker({ dateFormat: 'dd/mm/yy' });
//            $('.timepicker').wickedpicker({
//                template: false,
//                showInputs: false,
//                minuteStep: 5
//            });
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            var day = date.getDay();

            if (day != 1) {
                $(".th").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: -4,
                    maxDate: 1
                    //                    , beforeShowDay: noSunday

                });
            }
            else {
                $(".th").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: -4,
                    maxDate: 1
                    //                    , beforeShowDay: noSunday

                });
            }

            $(".th2").datepicker({
                dateFormat: 'dd/mm/yy',
                minDate: -4,
                maxDate: 60,
                beforeShowDay: noSunday
            });


        });
        function pageLoad() {

//            $('.timepicker').wickedpicker({
//                template: false,
//                showInputs: false,
//                minuteStep: 5
//            });
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            var day = date.getDay();

            if (day != 1) {
                $(".th").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: -4,
                    maxDate: 0
                    //                    , beforeShowDay: noSunday

                });
            }
            else {
                $(".th").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: -4,
                    maxDate: 0
                    //                    ,
                    //                    beforeShowDay: noSunday
                });
            }

        }
        function noSunday(date) {
            return [date.getDay() != 0, ''];
        }
        var Currentime = "";
        function ChangeStatus(elem) {
            //debugger;
            var leavefrom = document.getElementById(elem.id.substr(0, GetID(elem.id)) + "hdnleavefrom").value;
            var toleave = document.getElementById(elem.id.substr(0, GetID(elem.id)) + "hdnleaveto").value;

            var status = document.getElementById(elem.id.substr(0, GetID(elem.id)) + "ddlstatus").value;
            if (status != "-1") {
                // debugger;
                // alert(status);

                Currentime = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val();
                //                  $('#' + elem.id.substr(0, GetID(elem.id)) + "hdnintime").val($('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val()); 
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").val("");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").css('background-color', '#FFFFFF');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").css('background-color', '#FFFFFF');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").css('background-color', '#FFFFFF');

            }
            if (status == "-1") {

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").attr('disabled', 'disabled');

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").css('background-color', '#DDDFE4');

            }
            $('#' + elem.id.substr(0, GetID(elem.id)) + "diverror").removeClass("errorred");
            //alert(Currentime);
            //alert(status);
            if (status == "1") {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").removeClass("timepicker");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").removeAttr("disabled");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").removeClass("timepicker");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").removeClass("timepicker");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").removeClass("timepicker");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").css('background-color', '#DDDFE4');
            }
            else if (status == "2") {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").css('background-color', '#FFFF00');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").removeClass("timepicker");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").css('background-color', '#FFFF00');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").removeClass("timepicker");



                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").css('background-color', '#FFFF00');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").removeClass("timepicker");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").css('background-color', '#FFFF00');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").removeClass("timepicker");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").css('background-color', '#DDDFE4');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavedaycount").css('background-color', '#DDDFE4');

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val("");

            }
            else if (status == "3") {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").css('background-color', '#FFD27D');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val("");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").css('background-color', '#FFD27D');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val("");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").css('background-color', '#FFD27D');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").val("");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").css('background-color', '#FFD27D');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").val(leavefrom);
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").val(toleave);
            }
            else if (status == "4") {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").css('background-color', '#2AFF7F');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val("");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").css('background-color', '#2AFF7F');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val("");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").css('background-color', '#2AFF7F');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").val("");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").css('background-color', '#2AFF7F');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").val(leavefrom);
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").val(toleave);
            }
            else if (status == "5") {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").css('background-color', '#00AAFF');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val("");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").css('background-color', '#00AAFF');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val("");


                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").css('background-color', '#00AAFF');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").val("");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").css('background-color', '#00AAFF');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").removeClass("timepicker");
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").attr('disabled', 'disabled');
                //                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleavefrom").val(leavefrom);
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtleaveto").val(toleave);
            }
            else {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").css('background-color', '#ffffff');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").addClass("timepicker");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").removeAttr("disabled");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").css('background-color', '#ffffff');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").addClass("timepicker");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").removeAttr("disabled");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").css('background-color', '#ffffff');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").addClass("timepicker");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").removeAttr("disabled");

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").css('background-color', '#ffffff');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").addClass("timepicker");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").removeAttr("disabled");



            }
        }
        $(window).load(function () { $("#spinner").fadeOut("slow"); });

        function validate(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
        function disablekeys(evt) {
            var theEvent = evt || window.event;
            theEvent.returnValue = false;
            if (theEvent.preventDefault) theEvent.preventDefault();
        }
        ////        function CheckValid() {
        ////            if (typeof (Page_ClientValidate) == 'function') {
        ////                Page_ClientValidate();
        ////            }
        ////           
        ////            if (error != "") {
        ////                alert(error);
        ////                error = "";
        ////                return false;
        ////            }
        ////            else {
        ////                alert("page save successfully");
        ////                return true;
        ////            }
        ////            return flag;
        ////        }
        function getyesterdaydate() {
            var msgd = "";

        }
        function CheckValid() {
            var msg = ""; var error = "";
            $("[name*=ddlstatus]").each(function (i, item) {
                //                if (Page_IsValid) {

                debugger;

                if (item.selectedIndex == 0) {
                    if ($(item).closest("tr").find("input[name*=txtintime]").val() == "" || $(item).closest("tr").find("input[name*=txtintime_mm]").val() == "") {
                        msg = msg + "Please provide In time for " + $(item).closest("tr").find(".h3").html() + "\n";
                        //debugger;
                        $(item).closest("tr").find(".error").addClass('errorred');

                        error = msg;
                    }
                    if (error == "") {
                        //return true;
                    }
                    else {
                        return false;
                    }
                }
                if (item.selectedIndex == 2) {
                    if ($(item).closest("tr").find("input[name*=txtintime]").val() != "" || $(item).closest("tr").find("input[name*=txtintime_mm]").val() != "" || $(item).closest("tr").find("input[name*=txtouttime]").val() != "" || $(item).closest("tr").find("input[name*=txtoutfrom_mm]").val() != "") {
                        msg = msg + "You cannot select time for Week off user for " + $(item).closest("tr").find(".h3").html() + "\n";
                        //debugger;
                        $(item).closest("tr").find(".error").addClass('errorred');

                        error = msg;
                    }
                    if (error == "") {
                        //return true;
                    }
                    else {
                        return false;
                    }
                }
                if (item.selectedIndex == 4) {
                    debugger;
                    var fromdate = $(item).closest("tr").find("input[name*=txtleavefrom]").val();
                    var txtleaveto = $(item).closest("tr").find("input[name*=txtleaveto]").val();

                    if (fromdate != "" && txtleaveto != "") {

                        var SelectedDate = $("#txtattendencedate").val();
                        var Day = SelectedDate.split("/")[0];
                        var Month = SelectedDate.split("/")[1];
                        var Year = SelectedDate.split("/")[2];
                        var currentTime_sele = new Date(Month + "/" + Day + "/" + Year)

                        var dateFrom = fromdate;
                        var dateTo = txtleaveto;
                        var dateCheck = SelectedDate;

                        var d1 = dateFrom.split("/");
                        var d2 = dateTo.split("/");
                        var c = dateCheck.split("/");

                        var from = new Date(d1[2], parseInt(d1[1]) - 1, d1[0]);  // -1 because months are from 0 to 11
                        var to = new Date(d2[2], parseInt(d2[1]) - 1, d2[0]);
                        var check = new Date(c[2], parseInt(c[1]) - 1, c[0]);

                        if (check >= from && check <= to) {
                        }
                        else {
                            if ($(item).closest("tr").find("input[name*=txtintime]").val() == "") {
                                msg = msg + "Please provide In time for " + $(item).closest("tr").find(".h3").html() + "\n";
                                //debugger;
                                $(item).closest("tr").find(".error").addClass('errorred');
                                error = msg;
                            }
                        }
                    }
                    if (error == "") {
                        //return true;
                    }
                    else {
                        return false;
                    }
                }
                if ($(item).closest("tr").find("input[name*=txtouttime]").val() != "") {
                    if ($(item).closest("tr").find("input[name*=txtintime]").val() == "") {
                        msg = msg + "Please provide In time for " + $(item).closest("tr").find(".h3").html() + "\n";
                        //debugger;
                        $(item).closest("tr").find(".error").addClass('errorred');

                        error = msg;
                    }

                    if (error == "") {
                        //return true;
                    }
                    else {
                        return false;
                    }

                }
                //debugger;
                var starttimes = $(item).closest("tr").find("input[name*=txtintime]").val() + ':' + $(item).closest("tr").find("input[name*=txtintime_mm]").val();
                var Endtimes = $(item).closest("tr").find("input[name*=txtouttime]").val() + ':' + $(item).closest("tr").find("input[name*=txtoutfrom_mm]").val();

                if ($(item).closest("tr").find("input[name*=txtintime]").val() != "") {
                    if ($(item).closest("tr").find("input[name*=txtintime_mm]").val() == "") {
                        msg = msg + "Start time minute missing " + $(item).closest("tr").find(".h3").html() + "\n";
                        //alert(msg);
                        $(item).closest("tr").find(".error").addClass('errorred');
                        error = msg;
                    }
                }
                if ($(item).closest("tr").find("input[name*=txtouttime]").val() != "") {
                    if ($(item).closest("tr").find("input[name*=txtoutfrom_mm]").val() == "") {
                        msg = msg + "End time minute missing " + $(item).closest("tr").find(".h3").html() + "\n";
                        //alert(msg);
                        $(item).closest("tr").find(".error").addClass('errorred');
                        error = msg;
                    }
                }
                //debugger;
                var start = starttimes;

                if (item.selectedIndex != 0) {
                    if (starttimes == ":") {
                        starttime = new Date("November 13, 2013 " + "10:00");
                    }
                    else {
                        starttime = new Date("November 13, 2013 " + start);
                    }
                }
                else {
                    starttime = new Date("November 13, 2013 " + start);
                    //alert(starttime); new Date(1994, 12, 10);
                }


                var end = Endtimes;
                // starttime = new Date(starttime);
                //              alert(new Date(starttime).getTime());
                starttime = starttime.getTime();


                var endtime = "";
                if (item.selectedIndex == 0 || item.selectedIndex == 1 || item.selectedIndex == 2 || item.selectedIndex == 3 || item.selectedIndex == 4 || item.selectedIndex == 5) {
                    if (Endtimes == ":") {
                        endtime = new Date("November 13, 2013 " + "23:59"); //OD case set max end time .
                    }
                    else {
                        endtime = new Date("November 13, 2013 " + end);
                    }
                }
                else {
                    endtime = new Date("November 13, 2013 " + end);
                }
                endtime = endtime.getTime();
                //                    arguments.IsValid = (endtime >= starttime);
                if (endtime < starttime) {
                    msg = msg + "End time should be greater than Start time for " + $(item).closest("tr").find(".h3").html() + "\n";
                    //alert(msg);
                    $(item).closest("tr").find(".error").addClass('errorred');
                    error = msg;
                    //                        return false;
                }
                if (item.selectedIndex == 3 || item.selectedIndex == 4 || item.selectedIndex == 5) {

                    if ($(item).closest("tr").find("input[name*=txtleavefrom]").val() == "")
                        msg = msg + "Please select leave from date for " + $(item).closest("tr").find(".h3").html();
                    $(item).closest("tr").find(".error").addClass('errorred');
                    error = msg;
                    if (error != "") {
                        return;
                    }
                }
                if (item.selectedIndex == 3 || item.selectedIndex == 4 || item.selectedIndex == 5) {
                    if ($(item).closest("tr").find("input[name*=txtleaveto]").val() == "")
                        msg = msg + "Please select leave to date for " + $(item).closest("tr").find(".h3").html();
                    $(item).closest("tr").find(".error").addClass('errorred');
                    error = msg;
                    if (error != "") {
                        return;
                    }
                }
                if (GetdatePreDate() == 'yesterday') {
                    if ($(item).closest("tr").find("input[name*=txtintime]").val() != "" || $(item).closest("tr").find("input[name*=txtintime_mm]").val() != "") {
                        if ($(item).closest("tr").find("input[name*=txtouttime]").val() == "" || $(item).closest("tr").find("input[name*=txtoutfrom_mm]").val() == "") {
                            msg = msg + "Please provide In out time for " + $(item).closest("tr").find(".h3").html() + "\n";

                            $(item).closest("tr").find(".error").addClass('errorred');

                            error = msg;
                        }
                    }
                }
                if (error == "") {
                    //return true;
                }
                else {
                    return false;
                }
                if (error == "") {
                    $(item).closest("tr").find(".error").removeClass('errorred');
                    return true;
                }
                else {
                    return false;
                }

            });
            if (error != "") {

                alert(error);
                error = "";
                return false;
            }
            else {

                alert("Page save successfully.");
                return true;
            }
            return flag;
        }




        function ShowImagePreview() {
            xOffset = 100;
            yOffset = -450;
            $("a.preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' style='height:450px !important; width:320px !important;'/>" + c + "</p>");
                $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("slow");
            },

function () {
    this.title = this.t;
    $("#preview").remove();
});

            $("a.preview").mousemove(function (e) {
                $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
            });
        };

        function CheckLeaveCount(elem) {
            //debugger;
            var r = "";
            var agent = elem.value;

            var myArray = new Array()
            myArray[0] = '1';
            myArray[1] = '1.5';
            myArray[2] = '2';
            myArray[3] = '2.5';
            myArray[4] = '3';
            myArray[5] = '3.5';
            myArray[6] = '4';
            myArray[7] = '4.5';
            myArray[8] = '5';
            myArray[9] = '5.0';
            myArray[10] = '6';
            myArray[11] = '6.5';
            myArray[12] = '7';
            myArray[13] = '7.5';
            myArray[14] = '8';
            myArray[15] = '8.5';
            myArray[0] = '0.5';


            for (var i = 0; i < myArray.length; i++) {
                if (agent == myArray[i])
                    r = "true";
            }
            if (r == "true") {
                return true;
            }
            else {


                alert("invalid days");
                elem.value = "";
                return false;
            }
        }

        function CheckValidonchange() {
            var msg = ""; var error = "";
            $("[name*=ddlstatus]").each(function (i, item) {
                //                if (Page_IsValid) {
                if (item.selectedIndex == 2) {
                    if ($(item).closest("tr").find("input[name*=txtintime]").val() != "" || $(item).closest("tr").find("input[name*=txtintime_mm]").val() != "" || $(item).closest("tr").find("input[name*=txtouttime]").val() != "" || $(item).closest("tr").find("input[name*=txtoutfrom_mm]").val() != "") {
                        msg = msg + "You cannot select time for Week off user for " + $(item).closest("tr").find(".h3").html() + "\n";
                        //debugger;
                        $(item).closest("tr").find(".error").addClass('errorred');

                        error = msg;
                    }
                    if (error == "") {
                        //return true;
                    }
                    else {
                        return false;
                    }
                }
                if (item.selectedIndex == 0) {
                    if ($(item).closest("tr").find("input[name*=txtintime]").val() == "" || $(item).closest("tr").find("input[name*=txtintime_mm]").val() == "") {
                        msg = msg + "Please provide In time for " + $(item).closest("tr").find(".h3").html() + "\n";
                        //debugger;
                        $(item).closest("tr").find(".error").addClass('errorred');

                        error = msg;
                    }
                    if (error == "") {
                        //return true;
                    }
                    else {
                        return false;
                    }
                }

                //debugger;
                var starttimes = $(item).closest("tr").find("input[name*=txtintime]").val() + ':' + $(item).closest("tr").find("input[name*=txtintime_mm]").val();
                var Endtimes = $(item).closest("tr").find("input[name*=txtouttime]").val() + ':' + $(item).closest("tr").find("input[name*=txtoutfrom_mm]").val();

                if ($(item).closest("tr").find("input[name*=txtintime]").val() != "") {
                    if ($(item).closest("tr").find("input[name*=txtintime_mm]").val() == "") {
                        msg = msg + "Start time minute missing " + $(item).closest("tr").find(".h3").html() + "\n";
                        //alert(msg);
                        $(item).closest("tr").find(".error").addClass('errorred');
                        error = msg;
                    }
                }
                if ($(item).closest("tr").find("input[name*=txtouttime]").val() != "") {
                    if ($(item).closest("tr").find("input[name*=txtoutfrom_mm]").val() == "") {
                        msg = msg + "End time minute missing " + $(item).closest("tr").find(".h3").html() + "\n";
                        //alert(msg);
                        $(item).closest("tr").find(".error").addClass('errorred');
                        error = msg;
                    }
                }
                //debugger;
                var start = starttimes;

                if (item.selectedIndex != 0) {
                    if (starttimes == ":") {
                        starttime = new Date("November 13, 2013 " + "24:00");
                    }
                    else {
                        starttime = new Date("November 13, 2013 " + start);
                    }
                }
                else {
                    starttime = new Date("November 13, 2013 " + start);
                    //alert(starttime);
                }

                var end = Endtimes;
                starttime = starttime.getTime();

                var endtime = "";
                if (item.selectedIndex == 0 || item.selectedIndex == 1 || item.selectedIndex == 2 || item.selectedIndex == 3 || item.selectedIndex == 4 || item.selectedIndex == 5) {
                    if (Endtimes == ":") {
                        endtime = new Date("November 13, 2013 " + "24:00"); //OD case set max end time .
                    }
                    else {
                        endtime = new Date("November 13, 2013 " + end);
                    }
                }
                else {
                    endtime = new Date("November 13, 2013 " + end);
                }
                endtime = endtime.getTime();
                //                    arguments.IsValid = (endtime >= starttime);
                if (endtime > starttime == false) {
                    msg = msg + "End time should be greater than Start time for " + $(item).closest("tr").find(".h3").html() + "\n";
                    //alert(msg);
                    $(item).closest("tr").find(".error").addClass('errorred');
                    error = msg;
                    //                        return false;
                }
                if (item.selectedIndex == 3 || item.selectedIndex == 4 || item.selectedIndex == 5) {

                    if ($(item).closest("tr").find("input[name*=txtleavefrom]").val() == "" || $(item).closest("tr").find("input[name*=txtleaveto]").val() == "")
                        msg = msg + "Please select leave date for " + $(item).closest("tr").find(".h3").html() + "\n";
                    //alert(msg);
                    $(item).closest("tr").find(".error").addClass('errorred');
                    error = msg;

                }
                if (error == "") {
                    $(item).closest("tr").find(".error").removeClass('errorred');
                    return true;
                }
                else {
                    return false;
                }

            });
            if (error != "") {

                alert(error);
                error = "";
                return false;
            }
            else {
                //alert("page save successfully");
                return true;
            }
            return flag;
        }
        function ValidateTimeOnchange(elem) {

            var status = document.getElementById(elem.id.substr(0, GetID(elem.id)) + "ddlstatus").value;
            if (status == "2") {
                if ($('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val() != "" || $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").val() != "" || $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val() != "" || $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val() != "") {
                    alert("You cannot select time for Week off user for " + $(elem).closest("tr").find(".h3").html() + "\n");
                    $(elem).closest("tr").find(".error").addClass('errorred');
                    error = msg;
                }
                if (error == "") {
                    //return true;
                }
                else {
                    return false;
                }
            }
            starthh = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val();
            startmm = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").val();

            endhh = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val();
            endmm = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val();

            if (endhh == '23' && endmm == '59') {

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraouttime").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraoutfrom_mm").removeAttr("disabled");
            }
            else {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraouttime").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraoutfrom_mm").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraoutfrom_mm").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraouttime").val("");
            }
            if (endhh != '') {
                if (starthh == '') {
                    $(elem).closest("tr").find(".error").addClass('errorred');
                    alert("in time cannot be empty for " + $(elem).closest("tr").find(".h3").html());
                    return false;
                }
                else {

                    $(elem).closest("tr").find(".error").removeClass('errorred');
                    return true;
                }
            }
            if (starthh == '') {
                starthh = '00'
            }
            if (startmm == '') {
                startmm = '00'
            }

            if (endhh == '') {
                endhh = '00'
            }
            if (endmm == '') {
                endmm = '00'
            }

            var starttime = starthh + ":" + startmm;
            var endtime = endhh + ":" + endmm;

            var stt = new Date("May 26, 2016 " + starttime);
            stt = stt.getTime();

            var endt = new Date("May 26, 2016 " + endtime);
            endt = endt.getTime();
            if (stt >= endt) {
                $(elem).closest("tr").find(".error").addClass('errorred');
                alert("End time should be greater than Start time for " + $(elem).closest("tr").find(".h3").html());
                return false;
            }
            else {

                $(elem).closest("tr").find(".error").removeClass('errorred');
                return true;
            }
        }
        function removeerror(elem) {
            var starthh = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime").val();
            var startmm = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtintime_mm").val();
            endhh = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val();
            endmm = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val();
            if (endhh != "") {
                if (starthh != "") {
                    $(elem).closest("tr").find(".error").removeClass('errorred');
                }
                else {
                    alert("In time hours cannot be empty")
                    $(elem).closest("tr").find(".error").addClass('errorred');
                }
            }
        }
        function limitChar(event) {
            var key = ((window.event) ? (window.event.keyCode) : (event.which))
            return (key == 46) || (key == 8) || (key == 9) || (key == 37) || (key == 39) || (key >= 96 && key <= 105) || ((key == 86) && ((window.event) ? (window.event.ctrlKey) : (event.ctrlKey)));
        }
        function ValidateExtraTime(elem) {
            var endhh = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtouttime").val();
            var endmm = $('#' + elem.id.substr(0, GetID(elem.id)) + "txtoutfrom_mm").val();

            if (endhh == '23' && endmm == '59') {

                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraouttime").removeAttr("disabled");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraoutfrom_mm").removeAttr("disabled");
            }
            else {
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraouttime").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraoutfrom_mm").attr('disabled', 'disabled');
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraoutfrom_mm").val("");
                $('#' + elem.id.substr(0, GetID(elem.id)) + "txtExtraouttime").val("");
            }
        }
        function GetID(id) {
            //debugger;
            // alert()
            var res = id.split("_")[1];
            if (res.length == 6)
                return 21;
            else
                return 20;
        }
        function removeclass(elem) {
            $(elem).closest("tr").find(".error").removeClass('errorred');
        }
        function OpenFuturePlanLeave(elem) {
                      debugger;
            //            alert(elem.id);
            var rowid = elem.id.split("_")[1]
            userid = $('#' + "grdattendence_" + rowid + "_hdnUserID").val();
            fromleave = $('#' + "grdattendence_" + rowid + "_txtleavefrom").val();
            toleave = $('#' + "grdattendence_" + rowid + "_txtleaveto").val();
            var sURL = 'StaffAttandenceFutureLeavePopup.aspx?userid=' + userid + "&fromleave=" + fromleave + "&toleave=" + toleave;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 973, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }
        function SBClose() { }
       
    </script>
</head>
<body>


    <form id="form1" runat="server">
    <div>
        <span class="min-date-value"></span>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
            DisplayAfter="0">
            <ProgressTemplate>
                <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                    z-index: 52111; top: 40%; left: 45%; width: 6%;" />
            </ProgressTemplate>
        </asp:UpdateProgress>
         <div style="width: 1206px; margin:2px auto 0px;padding: 3px 10px; background-color: #405D99; color: #FFFFFF;text-transform: none; text-align:center;"> Staff Attendance Sheet
            <span style="color: Red;font-size: 10px;position: absolute;left:15%">All * (Asterisk) Mark Fields Are Mandatory</span>
         </div>
       <%--  <div style="width: 1225px; margin:0px auto;color: Red; text-align: left; font-size: 12px;">.</div>
                              <br />--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              
                <table border="0" class="item_list2 top-head-bar" cellpadding="0" cellspacing="0"
                    style="width: 1225px; border: 0px;margin-top: 5px;" align="center">
                   
                    <tr>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtattendencedate" onkeypress="return false;" autocomplete="off"
                                title="Choose attendance date" CssClass="th cc" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <span style="color:gray">Dept. name </span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddldeptname" AutoPostBack="True" OnSelectedIndexChanged="ddldeptname_SelectedIndexChanged"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                        <span style="color:gray"> Designation </span>
                           
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDesignation" AutoPostBack="True" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged"
                                runat="server" Width="155px">
                            </asp:DropDownList>
                        </td>
                        <td>
                        <span style="color:gray">User </span>
                            
                        </td>
                        <td>
                            <asp:DropDownList ID="ddluser" runat="server" Width="100px">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" CssClass="go" />
                        </td>
                    </tr>
                </table>
                
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnGo" />
            </Triggers>
        </asp:UpdatePanel>
        <%--<div id="clockdate">
  <div class="clockdate-wrapper">
    <div id="clock"></div>
    <div id="date"></div>
  </div>
</div>--%>

        <asp:GridView ID="grdattendence" runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center"
            OnRowDataBound="grdattendence_RowDataBound" ShowHeaderWhenEmpty="True" RowStyle-CssClass="GvGrid"
            CellPadding="1" Width="1225px" EmptyDataText="" RowStyle-ForeColor="#7E7E7E" CssClass="AddClass_Table" style="margin-top: 5px;"
            HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField ItemStyle-VerticalAlign="middle">
                    <HeaderTemplate>
                        Dept. name
                     </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldepartmentName" Style="text-transform: capitalize" CssClass="gray rotate"
                            Text='<%#Eval("departmentName") %>' runat="server"></asp:Label>
                       
                    </ItemTemplate>
                    <ItemStyle Width="85px" BackColor="#fff6fa" Font-Bold="true" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Designation
                     </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldesignationName" CssClass="gray" Text='<%#Eval("designationName") %>'
                            runat="server"></asp:Label>

                             <asp:HiddenField ID="hdndepartmentid" runat="server" Value='<%#Eval("departmentID") %>' />
                        <asp:HiddenField ID="hdndesignationID" runat="server" Value='<%#Eval("designationId") %>' />
                        <asp:HiddenField ID="hdnUserID" runat="server" Value='<%#Eval("UserID") %>' />
                        <asp:HiddenField ID="hdndeptcount" runat="server" Value='<%#Eval("departmentcount") %>' />

                    </ItemTemplate>
                    <ItemStyle Width="170px" BackColor="#fff6fa" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Employee name
                     </HeaderTemplate>
                    <ItemTemplate>
                        <div style="display: none" class="h3">
                            '<%#Eval("UserName") %>'</div>
                        <div class="error" id="diverror" runat="server">
                            <asp:Label ID="lblUserName" ForeColor="Black" Text='<%#Eval("UserName") %>' runat="server"></asp:Label></div>
                    </ItemTemplate>
                    <ItemStyle Width="170px" BackColor="#fff6fa" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        In-Time <sup style="color: Red; text-align: left; font-size: 12px; vertical-align: middle;">*</sup><br />
                        <hr style="border-color:#e4e0e0">
                        HH : MM
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtintime" onKeyDown="return limitChar(event);"  onkeyup="this.value = minmax(this.value, 0, 23)" MaxLength="2"
                            autocomplete="off" onblur="removeerror(this)" runat="server" type="number" Width="38%" ></asp:TextBox><span>:</span><asp:TextBox
                                MaxLength="2" type="number" onblur="removeerror(this)" onKeyDown="return limitChar(event);" autocomplete="off" ID="txtintime_mm" onkeyup="this.value = minmax(this.value, 0, 59)"
                                 runat="server" Width="38%"></asp:TextBox>
                        <asp:HiddenField ID="hdnintime" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="80px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Out-Time <sup style="color: Red; text-align: left; font-size: 12px; vertical-align: middle;">*</sup><br />
                         <hr style="border-color:#e4e0e0">
                        HH : MM</HeaderTemplate>
                    <ItemTemplate>
                        <asp:CustomValidator ID="cstmvEndDate" CausesValidation="true" ClientValidationFunction="compareTime"
                            Display="Dynamic" ErrorMessage="End time should be greater than Start time" ValidationGroup="Validation"
                            runat="server" />
                        <asp:TextBox ID="txtouttime" onchange="ValidateExtraTime(this);" onKeyDown="return limitChar(event);" type="number" onkeyup="this.value = minmax(this.value, 0, 23)"
                            MaxLength="2" autocomplete="off" runat="server" Width="36%"></asp:TextBox><span>:</span>
                        <asp:TextBox type="number" MaxLength="2" onchange="ValidateTimeOnchange(this);" ID="txtoutfrom_mm"
                            autocomplete="off" onKeyDown="return limitChar(event);" onkeyup="this.value = minmax(this.value, 0, 59)"
                            runat="server" Width="36%"></asp:TextBox>
                        <asp:HiddenField ID="hdnOuttime" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="80px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                       Ex-Ot-Time<br />
                         <hr style="border-color:#e4e0e0">
                        HH : MM</HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtExtraouttime" onKeyDown="return limitChar(event);" type="number"
                            onkeyup="this.value = minmax(this.value, 00, 8)" MaxLength="2" Enabled="false" autocomplete="off"
                            runat="server" Width="36%"></asp:TextBox><span>:</span>
                        <asp:TextBox type="number" MaxLength="2"  ID="txtExtraoutfrom_mm"
                            autocomplete="off" onKeyDown="return limitChar(event);" Enabled="false" onkeyup="this.value = minmax(this.value, 0, 59)"
                            runat="server" Width="36%"></asp:TextBox>
                        
                    </ItemTemplate>
                    <ItemStyle Width="80px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Status</HeaderTemplate>
                    <ItemTemplate>
                        <asp:DropDownList CausesValidation="true" ID="ddlstatus" onchange="ChangeStatus(this)"
                            runat="server" Width="95%">
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle Width="190px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Leave From</HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtleavefrom" onclick="removeclass(this);" autocomplete="off" onkeypress="return false;" CssClass="th2 cc" runat="server"
                            Width="90%"></asp:TextBox>
                           <asp:HiddenField ID="hdnleavefrom" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="90px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Leave To</HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtleaveto" onclick="removeclass(this);" autocomplete="off" onkeypress="return false;" CssClass="th2 cc" runat="server"
                            Width="90%"></asp:TextBox>
                            <asp:HiddenField ID="hdnleaveto" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="90px" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Future Leave</HeaderTemplate>
                    <ItemTemplate>
                       
                           <a href="javascript:void(0)" id="afuturelnk" runat="server" onclick="OpenFuturePlanLeave(this);">Future Leave</a>
                    </ItemTemplate>
                    <ItemStyle Width="90px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        Leave Day</HeaderTemplate>
                        <HeaderStyle  CssClass="hiddencol" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtleavedaycount" autocomplete="off" MaxLength="3" CssClass="groupOfTexbox" runat="server"
                            Width="90%"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="50px" VerticalAlign="Middle" CssClass="hiddencol"  />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                    <HeaderTemplate>
                        HR Remarks</HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtremarks" autocomplete="off" TextMode="MultiLine" runat="server" CssClass="myTextarea"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="190px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="image" ItemStyle-CssClass="IMageProfile">
                    <ItemTemplate>
                       
                            <a  href='<%# ResolveUrl("~/uploads/photo/" + Eval("PhotoPath").ToString()) %>'  visibility='<%# (Eval("PhotoPath") == null || string.IsNullOrEmpty(Eval("PhotoPath").ToString()) ) ? "hidden": "block" %>' : ;
                                class="preview thickbox <%# (Eval("PhotoPath") == null || string.IsNullOrEmpty(Eval("PhotoPath").ToString()) ) ? "hide_me": "" %>">
                                <img width="40px" border="0" src='<%# ResolveUrl("~/uploads/photo/" + Eval("PhotoPath").ToString()) %>'
                                   <%-- visible='<%# (Eval("PhotoPath") == null || string.IsNullOrEmpty(Eval("PhotoPath").ToString()) ) ? false: true %>' --%>
                                    />
                            </a>
                       
                       
                        
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                </asp:TemplateField>
                
            </Columns>
            <%--<emptydatarowstyle backcolor="LightBlue" forecolor="Red" />
        <emptydatatemplate>


            No Data Found.  

        </emptydatatemplate> --%>
        </asp:GridView>
     
        <div style="margin: 10px auto; text-align: center">
            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="Validation" OnClientClick="JavaScript:return CheckValid();"
                title="Save record !" CssClass="do-not-include submit tooltip btnsave" Text="Submit"
                OnClick="btnSubmit_Click" />
            <%-- <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
                        Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />--%>
        </div>
        <br />
       
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
      
         
    </div>
     
    </form>
</body>
</html>
