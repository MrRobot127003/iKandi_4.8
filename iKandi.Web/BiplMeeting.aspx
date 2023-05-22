<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BiplMeeting.aspx.cs" Inherits="iKandi.Web.BiplMeeting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../css/jquery.timepicker.css" rel="stylesheet" type="text/css" />
<script src="../../js/jquery-1.12.4.min.js" type="text/javascript"></script>
<script src="../../js/jquery.timepicker.js" type="text/javascript"></script>--%>
    <script src="js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="js/jquery.form.js" type="text/javascript"></script>
    <script src="js/jquery.autocomplete.js" type="text/javascript"></script>
    <style>
        #modalPopup
        {
            position: fixed;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
        }
        #divuser
        {
            width: 300px;
            margin: 0 auto;
            background: #ffffff;
            position: absolute;
            top: 10%;
            left: 40%;
            z-index: 2;
            min-height: 150px;
            text-align: center;
        }
        .headerTop
        {
            width: 100%;
            padding: 0px 0px;
            margin-bottom: 10px;
        }
        .btn_left
        {
            margin-left: 1px;
        }
        
        .selected_row
        {
            background-color: #A1DCF2;
        }
        .AddClass_Table td
        {
            line-height: 14px;
            height: 20px;
        }
        input[type="botton"].fpcubtn:focus
        {
            border: 0px;
        }
        #modalPopup h2
        {
            margin-top: 0px;
            padding: 2px 0px;
        }
        .txtColorBlur
        {
            background: #357ebd;
            border: 1px solid #357ebd;
        }
        .backhover:hover
        {
            background: #bd1313;
            border: 1px solid #bd1313;
        }
        .AddClass_Table td input[type="text"]
        {
            text-transform: capitalize;
        }
        /*.AddClass_Table tr:nth-child(odd)
                {
                    background: #f1f1f1;
                }
            .AddClass_Table tr:hover:nth-child(odd)
            {
                background: #fff;
            }*/
        .alt-row
        {
            background-color: #f1f1f1;
        }
        
        .oddRow
        {
            background: #f1f1f1;
        }
        .evenRow
        {
            background: #fff;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            $(".AutoUser").autocomplete("/Webservices/iKandiService.asmx/SuggestAuditors", { dataType: "xml", datakey: "string", max: 100 });
            //            $(function () {
            //                $("[id*=grdMeetingsbipl] td").bind("click", function () {
            ////                    var row = $(this).parent();
            ////                    $("[id*=grdMeetingsbipl] tr").each(function () {
            ////                        if ($(this)[0] != row[0]) {
            ////                            $("td", this).removeClass("selected_row");
            ////                        }
            ////                    });
            //                    $("[id*=grdMeetingsbipl] tr").each(function () {
            //                        if (!$(this).hasClass("selected_row")) {
            //                            $(this).addClass("selected_row");
            //                        } else {
            //                            $(this).removeClass("selected_row");
            //                        }
            //                    });
            ////                    $("td", row).each(function () {
            ////                        if (!$(this).hasClass("selected_row")) {
            ////                            $(this).addClass("selected_row");
            ////                        } else {
            ////                            $(this).removeClass("selected_row");
            ////                        }
            ////                    });
            //                });
            //            });
            //        }
        }
        $(document).ready(function () {

            $(".AutoUser").autocomplete("/Webservices/iKandiService.asmx/SuggestAuditors", { dataType: "xml", datakey: "string", max: 100 });


            $(".hidetdd").hide();
            $('#Daily').hide();
            $('#DailyWeekly').hide();
            $('#DailyMonthly').hide();
            $('#QuarterlyMonthly').hide();
            $('#YearlyAcc').hide();
            $("select.accurrence").change(function () {
                var selectedAccurrence = $(this).children("option:selected").val();
                if (selectedAccurrence == 1) {
                    $('#Daily').show();
                    $('#DailyWeekly').hide();
                    $('#DailyMonthly').hide();
                    $('#QuarterlyMonthly').hide();
                    $('#YearlyAcc').hide();
                }
                if (selectedAccurrence == 4) {
                    $('#Daily').hide();
                    $('#DailyWeekly').show();
                    $('#DailyMonthly').hide();
                    $('#QuarterlyMonthly').hide();
                    $('#YearlyAcc').hide();
                }
                if (selectedAccurrence == 2) {
                    $('#Daily').hide();
                    $('#DailyWeekly').hide();
                    $('#QuarterlyMonthly').hide();
                    $('#YearlyAcc').hide();
                    $('#DailyMonthly').show();
                }
                if (selectedAccurrence == 3) {
                    $('#Daily').hide();
                    $('#DailyWeekly').hide();
                    $('#DailyMonthly').hide();
                    $('#YearlyAcc').hide();
                    $('#QuarterlyMonthly').show();
                }
                if (selectedAccurrence == 5) {
                    $('#Daily').hide();
                    $('#DailyWeekly').hide();
                    $('#DailyMonthly').hide();
                    $('#YearlyAcc').show();
                    $('#QuarterlyMonthly').hide();
                }

            });
            $('.controlCheckBox').click(function () {
                var CheckBoxTrue = $(this).prop('checked');
                if (CheckBoxTrue == true) {
                    $(".hidetdd").show();
                    $('.desabledSelect').prop('disabled', true);
                    $('#DailyWeekly select').prop('disabled', true);
                    $('.textboxwidth').prop('disabled', true);
                } else {
                    $('.desabledSelect').prop('disabled', false);
                    $(".hidetdd").hide();
                    $('.textboxwidth').prop('disabled', false);
                    $('#DailyWeekly select').prop('disabled', false);
                }

            });

            //jQuery('.setTimeExample').timepicker();
        });
        function ValidatePageAndSave() {
            debugger;
            MeetingSchedule_Id = 0;
            var accurrence = $('.accurrence').val();

            var manualcheck = 0;
            var remember = document.getElementById("chkmanualcheck");
            if (remember.checked) {
                manualcheck = 1;
            }
            else {
                manualcheck = 0;
            }

            var txtname = $('.txtname').val();
            var txtDailyTime = $('.txtDailyTime').val();
            var txtWeeklyTime = $('.txtWeeklyTime').val();
            var ddlWeekly = $('.ddlWeekly').val();
            var ddlMonthly = $('.ddlMonthly').val();
            var txtMonthlyTime = $('.txtMonthlyTime').val();
            var ddlQuarter = $('.ddlQuarter').val();
            var ddlQuarterDay = $('.ddlQuarterDay').val();
            var txtQuarterDaysTime = $('.txtQuarterDaysTime').val();
            var ddlYearMonth = $('.ddlYearMonth').val();
            var ddlYearDays = $('.ddlYearDays').val();
            var txtYearTime = $('.txtYearTime').val();
            var ddlManualdays = $('.ddlManualdays').val();
            var txtManualtime = $('.txtManualtime').val();
            var txtParticipants = $('.txtParticipants').val();
            var txtDescription = $('.txtDescription').val();

            //-------------------------------------------------------//
            debugger;

            var TimeZone;
            var Month;
            var Day;
            var Time;
            var IsManual;

            var Manual_TimeZone;
            var Manual_Month;
            var Manual_Day;
            var Manual_Time;

            var result = true;
            if (txtname == "") {
                alert("Enter event name!");
                return false;
            }
            if (manualcheck == false) {
                if (accurrence == "-1") {
                    alert("select accurrence!");
                    IsManual = 0;
                    return false;
                }
                else {
                    if (accurrence == "1") {

                        if (txtDailyTime == "") {
                            alert("Enter Daily Time!");
                            return false;
                        }
                        else {
                            TimeZone = 1;
                            Time = txtDailyTime;
                        }
                    }
                    if (accurrence == "4") {
                        TimeZone = 4;
                        if (ddlWeekly == "-1") {
                            alert("Select Weekly days!");
                            return false;
                        }
                        if (txtWeeklyTime == "") {
                            alert("Select Weekly time!");
                            return false;
                        }
                    }
                    if (accurrence == "2") {
                        TimeZone = 2;
                        if (ddlMonthly == "-1") {
                            alert("Select monthly days!");
                            return false;
                        }
                        else {
                            Month = ddlMonthly;
                        }
                        if (txtMonthlyTime == "") {
                            alert("Select Monthly Time!");
                            return false;
                        }
                        else {
                            Time = txtMonthlyTime;
                        }
                    }
                    if (accurrence == "3") {
                        TimeZone = 3;
                        if (ddlQuarter == "-1") {
                            alert("Select Quarter!");
                            return false;
                        }
                        else {
                            Month = ddlQuarter;
                        }
                        if (ddlQuarterDay == "-1") {
                            alert("Select Quarter Day!");
                            return false;
                        }
                        else {
                            Day = ddlQuarterDay;
                        }
                        if (txtQuarterDaysTime == "") {
                            alert("Select Quarter Days Time!");
                            return false;
                        }
                        else {
                            Time = txtQuarterDaysTime;
                        }
                    }
                    if (accurrence == "5") {
                        TimeZone = 5;
                        if (ddlYearMonth == "-1") {
                            alert("Select Year Month!");
                            return false;
                        }
                        else {
                            Month = ddlYearMonth;
                        }
                        if (ddlYearDays == "-1") {
                            alert("Select Year Days!");
                            return false;
                        }
                        else {
                            Day = ddlYearDays;
                        }
                        if (txtYearTime == "") {
                            alert("Select Year Time!");
                            return false;
                        }
                        else {
                            Time = txtYearTime;
                        }
                    }
                }
            }
            else {
                IsManual = 1;
                Manual_TimeZone = 1;
                if (ddlManualdays == "-1") {
                    alert("Select Manual Days!");
                    return false;
                }
                else {
                    Manual_Month = ddlManualdays;
                }
                if (txtManualtime == "") {
                    alert("Enter Manual time!");
                    return false;
                }
                else {
                    Manual_Time = txtManualtime;
                }
            }

            if (txtParticipants == "") {
                alert("Enter Participants!");
                return false;
            }

            if (txtDescription == "") {
                alert("Enter Description!");
                return false;
            }
            //SaveBiplMeetingInfo(int MeetingSchedule_Id, int MeetingCategory_Id, string MeetingName, int TimeZone, int Month, int Day, string Time, int IsManual, int Manual_TimeZone, int Manual_Month, int Manual_Day, string Manual_Time, string Participate, string Description)
            //        var url = "../../Webservices/iKandiService.asmx";
            //        $.ajax({
            //            type: "POST",
            //            url: url + "/SaveBiplMeetingInfo",
            //            data: "{ MeetingSchedule_Id:'" + MeetingSchedule_Id + "', MeetingCategory_Id:'" + TimeZone + "', MeetingName:'" + txtname + "', TimeZone:'" +
            //            TimeZone + "', Month:'" + Month + "', Day:'" + Day + "', Time:'" + Time + "', IsManual:'" +
            //            IsManual + "', Manual_TimeZone:'" + Manual_TimeZone + "', Manual_Month:'" + Manual_Month + "', Manual_Day:'" + Manual_Day + "', Manual_Time:'" +
            //            Manual_Time + "' , Participate:'" + txtParticipants + "', Description:'" + txtDescription + "'}",
            //            contentType: "application/json; charset=utf-8",
            //            dataType: "json",
            //            success: OnSuccessCall,
            //            error: OnErrorCall
            //        });

            //        function OnSuccessCall(response) {
            //            alert("Saved Sucessfully");
            //            
            //        }

            //        function OnErrorCall(response) {
            //            alert(response.status + " " + response.statusText);
            //        }
        }

        //$(document).ready(function () {
        //$(".AutoUser").autocomplete("/Webservices/iKandiService.asmx/SuggestAuditors", { dataType: "xml", datakey: "string", max: 100 });
        //  $("input.AutoUser", "#main_content").autocomplete("/Webservices/iKandiService.asmx/SuggestStyleNumberCode", { dataType: "xml", datakey: "string", max: 100 });
        //});
        function Checktext() {
            debugger;
            if ($("#txtuser").val() == "") {
                alert("please fill user");
                return false;
            }
        }
        //        $(document).ready(function () {

        //            $('.userinf').hover(

        //               function () {
        ////                   $(this).css({ "background-color": "red" });
        //               },

        //               function () {
        ////                   $(this).css({ "background-color": "blue" });
        //               }
        //            );

        //        });

        //        $(function () {
        //            $("[id*=grdMeetingsbipl] td").bind("click", function () {
        //                var row = $(this).parent();
        //                $("[id*=grdMeetingsbipl] tr").each(function () {
        //                    if ($(this)[0] != row[0]) {
        //                        $("td", this).removeClass("selected_row");
        //                    }
        //                });
        //                $("td", row).each(function () {
        //                    if (!$(this).hasClass("selected_row")) {
        //                        $(this).addClass("selected_row");
        //                    } else {
        //                        $(this).removeClass("selected_row");
        //                    }
        //                });
        //            });
        //        });
    </script>
</head>
<body>
    <form id="form1" autocomplete="off"  runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="udpnl"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="udpnl" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="CarrotSign" style="width: 100%; background: #39589c; text-align: center;
                color: #fff; padding: 2px 0px; font-size: 14px; margin-bottom: 2px; font-weight: 500;">
                BIPL Meetings</div>
            <div class="debitnote-table" style="max-width: 99.8%; margin: 0px auto;">
                <table runat="server" id="tbladd" visible="false" width="100%" style="margin-bottom: 10px;"
                    class="AddClass_Table">
                    <tbody>
                        <tr>
                            <th style="min-width: 80px; max-width: 80px;">
                                Name
                            </th>
                            <th style="min-width: 160px; max-width: 160px;">
                                <asp:DropDownList ID="ddlaccurrence" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged"
                                    class="accurrence desabledSelect" runat="server">
                                </asp:DropDownList>
                            </th>
                            <th style="min-width: 160px; max-width: 160px;">
                                <span style="position: relative; top: -2px;">Manual</span>
                                <asp:CheckBox ID="ChkIsmanual" runat="server" OnCheckedChanged="ChkIsmanual_CheckedChanged"
                                    AutoPostBack="true"></asp:CheckBox>
                            </th>
                            <th style="min-width: 70px; max-width: 70px;">
                                Participants
                            </th>
                            <th style="min-width: 80px; max-width: 80px;">
                                Description
                            </th>
                            <th style="min-width: 65px; max-width: 65px;">
                                Action
                            </th>
                        </tr>
                        <tr>
                            <td style="min-width: 80px; max-width: 80px;">
                                <asp:TextBox ID="txtmeetingname"  AutoPostBack="True" OnTextChanged="txtmeetingname_TextChanged"
                                    CssClass="txtname" runat="server"></asp:TextBox>
                            </td>
                            <td class="textCenter" style="min-width: 160px; max-width: 160px;">
                                <asp:DropDownList ID="ddlDailyTime" Visible="false" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMonthly" Visible="false" runat="server" Style="width: 82px;"
                                    class="desabledSelect ddlMonthly">
                                    <asp:ListItem Value="-1">Select Date</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">16</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>                                 
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMonthlyTime" Visible="false" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlWeekly" runat="server" Visible="false" class="desabledSelect ddlWeekly">
                                    <asp:ListItem Value="-1">Select Day</asp:ListItem>
                                    <%-- <asp:ListItem Value="1">Sunday</asp:ListItem>--%>
                                    <asp:ListItem Value="2">Monday</asp:ListItem>
                                    <asp:ListItem Value="3">Tuesday</asp:ListItem>
                                    <asp:ListItem Value="4">Wednesday</asp:ListItem>
                                    <asp:ListItem Value="5">Thursday</asp:ListItem>
                                    <asp:ListItem Value="6">Friday</asp:ListItem>
                                    <asp:ListItem Value="7">Saturday</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlWeeklyTime" Visible="false" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlQuarter" Visible="false" runat="server" Style="width: 95px;"
                                    class="desabledSelect ddlQuarter">
                                    <asp:ListItem Value="-1">Quarter Month</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlQuarterDay" Visible="false" runat="server" Style="width: 50px;"
                                    class="desabledSelect ddlQuarterDay">
                                    <asp:ListItem Value="-1">Date</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">15</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList Visible="false" ID="ddlQuarterDaysTime" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlyearonetimeonly" Visible="false" runat="server">
                                <asp:ListItem Value="-1">Year</asp:ListItem>
                                <asp:ListItem Selected="True" Value="2019">2019</asp:ListItem>
                                <asp:ListItem Value="2020">2020</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlYearMonth" Visible="false" runat="server" Style="width: 58px;"
                                    class="desabledSelect ddlYearMonth">
                                    <asp:ListItem Value="-1">Month</asp:ListItem>
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlYearDays" Visible="false" runat="server" Style="width: 96px;"
                                    class="desabledSelect ddlYearDays">
                                    <asp:ListItem Value="-1">Date</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">15</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlYearTime" Visible="false" runat="server">
                                </asp:DropDownList>

                                 <asp:DropDownList ID="ddlOneTime_Month" Visible="false" runat="server" Style="width: 58px;"
                                    class="desabledSelect ddlYearMonth">
                                    <asp:ListItem Value="-1">Month</asp:ListItem>
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                                 <asp:DropDownList ID="ddlOneTime_Day" Visible="false" runat="server" Style="width: 70px;"
                                    class="desabledSelect ddlYearDays">
                                    <asp:ListItem Value="-1">Day</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">15</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                </asp:DropDownList>
                                  
                                <asp:DropDownList ID="ddlOneTime_Time" Visible="false" runat="server">
                                </asp:DropDownList>
                              
                            </td>
                            <td style="min-width: 160px; max-width: 160px;" class="textCenter">
                                <asp:DropDownList ID="ddlManualQuarter" Visible="false" runat="server" Style="width: 95px;"
                                    class="desabledSelect ddlQuarter">
                                    <asp:ListItem Value="-1">Select Quarter Month</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlWeeklyManual" runat="server" Visible="false" class="desabledSelect ddlWeekly">
                                    <asp:ListItem Value="-1">Select Day</asp:ListItem>
                                    <%-- <asp:ListItem Value="1">Sunday</asp:ListItem>--%>
                                    <asp:ListItem Value="2">Monday</asp:ListItem>
                                    <asp:ListItem Value="3">Tuesday</asp:ListItem>
                                    <asp:ListItem Value="4">Wednesday</asp:ListItem>
                                    <asp:ListItem Value="5">Thursday</asp:ListItem>
                                    <asp:ListItem Value="6">Friday</asp:ListItem>
                                    <asp:ListItem Value="7">Saturday</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlYearMonthManual" Visible="false" runat="server" Style="width: 58px;"
                                    class="desabledSelect ddlYearMonth">
                                    <asp:ListItem Value="-1">Month</asp:ListItem>
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlManualdays" Visible="false" runat="server" class="ddlManualdays"
                                    Style="width: 56px;">
                                    <asp:ListItem Value="-1"> Date</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">15</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlManualtime" Visible="false" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="min-width: 60px; max-width: 60px;">
                                <asp:ImageButton OnClick="btn_Edit_Click" ID="btn_Edit" ImageUrl="../../images/edit2.png"
                                    Style="position: relative; top: 2px; float: right; width: 12px" ToolTip="Edit"
                                    CommandName="Edit" runat="server" />
                                <%--<asp:TextBox ID="txtParticipants" runat="server" class="txtParticipants" style="width: 50px;"></asp:TextBox>--%>
                                <asp:Label ID="txtparticipante" runat="server"></asp:Label>
                            </td>
                            <td style="min-width: 80px; max-width: 80px;">
                                <asp:TextBox ID="txtDescription" runat="server" class="txtDescription" Style="text-transform: capitalize;"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td class="textCenter" style="min-width: 60px; max-width: 60px;">
                                <asp:Button ID="btnadd" Text="Submit" runat="server" Style="padding: 2px 5px" class="btnbutton_Com"
                                    OnClick="btnadd_Click" />
                                <asp:Button ID="btncancel" Text="Cancel" runat="server" Style="padding: 2px 5px"
                                    class="btnbutton_Com txtColorBlur" OnClick="btncancel_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:GridView ID="grdMeetingsbipl" CssClass="AddClass_Table" runat="server" AutoGenerateColumns="False"
                    ShowHeader="true" OnRowEditing="grdMeetingsbipl_RowEditing" OnRowDataBound="grdMeetingsbipl_RowDataBound"
                    Width="100%" BorderWidth="0" OnRowCommand="grdMeetingsbipl_RowCommand" OnRowDeleting="grdMeetingsbipl_RowDeleting"
                    Style="margin-bottom: 2px;">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblmeetingname" Text='<%# Bind("MeetingName") %>' runat="server" />
                                <asp:HiddenField ID="hdnMeetingSchedule_Id" runat="server" Value='<%# Bind("MeetingSchedule_Id") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Occurrence">
                            <ItemTemplate>
                                <asp:Label ID="lblOccurrence" runat="server" />
                                <asp:HiddenField ID="hdnMeetingCategory_Id" runat="server" Value='<%# Bind("MeetingCategory_Id") %>' />
                                <asp:HiddenField ID="hdnMonth" runat="server" Value='<%# Bind("Month") %>' />
                                <asp:HiddenField ID="hdnDay" runat="server" Value='<%# Bind("Day") %>' />
                                <asp:HiddenField ID="hdnTime" runat="server" Value='<%# Bind("Time") %>' />
                                <asp:HiddenField ID="hdnyear" runat="server" Value='<%# Bind("Years") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="170px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manual">
                            <ItemTemplate>
                                <asp:Label ID="lblManual" runat="server" />
                                <asp:HiddenField ID="hdnManual_Day" runat="server" Value='<%# Bind("Manual_Day") %>' />
                                <asp:HiddenField ID="hdnManual_Time" runat="server" Value='<%# Bind("Manual_Time") %>' />
                                <asp:HiddenField ID="hdnManual_Month" runat="server" Value='<%# Bind("Manual_Month") %>' />
                                <asp:HiddenField ID="hdnIsManual" runat="server" Value='<%# Bind("IsManual") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="170px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Participants">
                            <ItemTemplate>
                                <asp:Label ID="lblParticipants" Text='<%# Bind("Participate") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discription">
                            <ItemTemplate>
                                <asp:Label ID="lblDiscription" ForeColor="gray" Text='<%# Bind("Description") %>'
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="160px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkedit" CommandName="edit" CommandArgument='<%# Bind("MeetingSchedule_Id") %>'
                                    ImageUrl="../../images/edit2.png" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkdelete" OnClientClick="return confirm('Are you sure want to delete');"
                                    ToolTip="Delete participants" CommandName="Delete" ImageUrl="images/delete-icon.png"
                                    runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="modalPopup" runat="server" visible="false">
                <div id="divuser" runat="server" visible="false">
                    <div class="headerTop">
                        <h2>
                            Add Participants
                            <asp:Button ID="btnhide" Text="X" runat="server" CssClass="fpcubtn" Style="float: right;
                                background: transparent; color: #fff; border: 0px;" OnClick="btnhide_Click" /></h2>
                    </div>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 80%; margin: 0 auto;">
                        <thead>
                            <tr>
                                <th style="text-align: left;">
                                    <asp:TextBox ID="txtuser" CssClass="AutoUser" onpaste="return false;" runat="server"></asp:TextBox>
                                </th>
                                <th style="text-align: left;">
                                    <asp:Button ID="btnadduser" Text="add" runat="server" OnClientClick="return Checktext()"
                                        class="btnbutton_Com" OnClick="btnadduser_Click" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="2" style="text-align: left;">
                                    <asp:Label ID="lbluserlist" Visible="false" runat="server"></asp:Label>
                                    <asp:GridView ID="grdparticipaint" CssClass="AddClass_Table" runat="server" AutoGenerateColumns="False"
                                        ShowHeader="true" OnRowDataBound="grdparticipaint_RowDataBound" OnRowDeleting="grdparticipaint_RowDeleting"
                                        OnRowCommand="grdparticipaint_RowCommand" Width="100%" BorderWidth="0" Style="margin-bottom: 2px;">
                                        <RowStyle CssClass="oddRow" />
                                        <AlternatingRowStyle CssClass="evenRow" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="List of participants">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" Text='<%# Container.DataItem %>' runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="120px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="lnkdelete" OnClientClick="return confirm('Are you sure want to delete');"
                                                        ToolTip="Delete participants" CommandName="Delete" ImageUrl="images/delete-icon.png"
                                                        runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" HorizontalAlign="center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:HiddenField ID="hdnuserlist" runat="server" />
                </div>
            </div>
            <div class="btn_left">
                <asp:Button ID="btnaddnew" Text="Add New" runat="server" ToolTip="Create new event"
                    class="btnbutton_Com" OnClick="btnaddnew_Click" />
                <asp:Button ID="Button1" Text="Close" runat="server" ToolTip="Close this popup" class="btnbutton_Com txtColorBlur backhover"
                    OnClientClick="javascript:self.parent.Shadowbox.close();" />
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
