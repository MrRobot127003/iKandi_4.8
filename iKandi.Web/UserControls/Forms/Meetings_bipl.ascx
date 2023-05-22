<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Meetings_bipl.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.Meetings_bipl" %>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<link href="../../css/jquery.timepicker.css" rel="stylesheet" type="text/css" />
<script src="../../js/jquery-1.12.4.min.js" type="text/javascript"></script>
<script src="../../js/jquery.timepicker.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {

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
        jQuery('.setTimeExample').timepicker();
    });
    function ValidatePageAndSave() {

        MeetingSchedule_Id = 0;
        var accurrence = $('.accurrence').val();
        var manualcheck = $('.manualcheck').prop('checked');
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
    
    

</script>
<div class="debitnote-table" style="max-width: 600px; margin: 5px auto;">
    <table style="max-width: 100%; margin-bottom: 10px;" class="AddClass_Table">
        <tbody>
            <tr>
                <th>
                    Name
                </th>
                <th style="min-width: 160px;">
                    <asp:DropDownList ID="ddlaccurrence" class="accurrence desabledSelect" runat="server">
                    </asp:DropDownList>
                    <%-- <select class="accurrence desabledSelect">
                        <option value="-1">Select Occurrence</option>
                        <option value="1">Daily</option>
                        <option value="2">Weekly</option>
                        <option value="3">Monthly</option>
                        <option value="4">Quarterly</option>
                        <option value="5">Yearly</option>
                    </select>--%>
                </th>
                <th style="min-width: 141px;">
                    <input type="checkbox" class="controlCheckBox manualcheck" name="vehicle1" value="Bike"><span
                        style="position: relative; top: -2px;">Manual</span>
                </th>
                <th>
                    Participants
                </th>
                <th>
                    Description
                </th>
                <th>
                    Action
                </th>
            </tr>
            <tr>
                <td style="min-width: 80px;">
                    <asp:TextBox ID="txtmeetingname" runat="server" 
                        ></asp:TextBox>
                </td>
                <td class="textCenter">
                    <span id="Daily">
                        <asp:TextBox ID="txtDailyTime" runat="server" class="textboxwidth setTimeExample txtDailyTime"
                            placeholder="Time"></asp:TextBox>
                    </span><span id="DailyWeekly">
                        <asp:DropDownList ID="ddlWeekly" runat="server" class="desabledSelect ddlWeekly">
                            <asp:ListItem Value="-1">Day></asp:ListItem>
                            <asp:ListItem Value="1">Sunday></asp:ListItem>
                            <asp:ListItem Value="2">Monday></asp:ListItem>
                            <asp:ListItem Value="3">Tuesday></asp:ListItem>
                            <asp:ListItem Value="4">Wednesday></asp:ListItem>
                            <asp:ListItem Value="5">Thursday></asp:ListItem>
                            <asp:ListItem Value="6">Friday></asp:ListItem>
                            <asp:ListItem Value="6">Saturday></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtWeeklyTime" runat="server" class="textboxwidth setTimeExample txtWeeklyTime"
                            Style="width: 43%;" placeholder="Time"></asp:TextBox>
                    </span><span id="DailyMonthly">
                        <asp:DropDownList ID="ddlMonthly" runat="server" Style="width: 80px;" class="desabledSelect ddlMonthly">
                            <asp:ListItem Value="-1">Select Date></asp:ListItem>
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
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
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
                        <asp:TextBox ID="txtMonthlyTime" runat="server" class="setTimeExample textboxwidth txtMonthlyTime"
                            placeholder="Time" Style="width: 50px;"></asp:TextBox>
                    </span><span id="QuarterlyMonthly">
                        <select>
                            <option value="-1">Quarter Month</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                        </select>
                        <asp:DropDownList ID="ddlQuarter" runat="server" Style="width: 58px;" class="desabledSelect ddlQuarter">
                            <asp:ListItem Value="-1">Quarter Month></asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="-1">Quarter Month></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlQuarterDay" runat="server" Style="width: 50px;" class="desabledSelect ddlQuarterDay">
                            <asp:ListItem Value="-1">Select Date></asp:ListItem>
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
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
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
                        <asp:TextBox ID="txtQuarterDaysTime" runat="server" class="setTimeExample textboxwidth txtQuarterDaysTime"
                            placeholder="Time" Style="width: 40px;"></asp:TextBox>
                    </span><span id="YearlyAcc">
                        <asp:DropDownList ID="ddlYearMonth" runat="server" Style="width: 58px;" class="desabledSelect ddlYearMonth">
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
                        <asp:DropDownList ID="ddlYearDays" runat="server" Style="width: 50px;" class="desabledSelect ddlYearDays">
                            <asp:ListItem Value="-1">Select Date></asp:ListItem>
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
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
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
                        <asp:TextBox ID="txtYearTime" runat="server" class="setTimeExample textboxwidth txtYearTime"
                            placeholder="Time" Style="width: 40px;"></asp:TextBox>
                       
                    </span>
                </td>
                <td style="min-width: 80px;" class="textCenter">
                    <span class="hidetdd">
                      
                         <asp:DropDownList ID="ddlManualdays" runat="server" class="ddlManualdays" style="width: 60px;">
                            <asp:ListItem Value="-1">Select Date></asp:ListItem>
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
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
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
                        

                         <asp:TextBox ID="txtManualtime" runat="server" class="setTimeExample txtManualtime" style="width: 70px;"></asp:TextBox>
                    </span>
                </td>
                <td style="min-width: 80px;">
                   
                     <asp:TextBox ID="txtParticipants" runat="server" class="txtParticipants" style="width: 50px;"></asp:TextBox>
                </td>
                <td style="max-width: 100px; min-width: 100px;">
                    
                    <asp:TextBox ID="txtDescription" runat="server" class="txtDescription" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="textCenter">
                   
                        <asp:Button ID="btnadd" Text="add" runat="server"  class="btnbutton_Com" 
                            onclick="btnadd_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:GridView ID="grdMeetingsbipl" runat="server" CssClass="AddClass_Table" AutoGenerateColumns="false"
        BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <%--<asp:Label ID="lblMeetingName" runat="server" ></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Occurrence">
                <ItemTemplate>
                    <%-- <asp:Label ID="lblAccurrence" runat="server" ></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Manual">
                <ItemTemplate>
                    <%--   <asp:Label="lblManual" runat="server" ></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Participants">
                <ItemTemplate>
                    <%-- <asp:Label="lblParticipants" runat="server" ></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
