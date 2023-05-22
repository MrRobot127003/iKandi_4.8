<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmSlotAdmin.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.frmSlotAdmin" %>
<link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style1
    {
        width: 12%;
    }
    .style2
    {
        width: 21%;
    }
    .style3
    {
        width: 22%;
    }
    .font
    {
        font-size: 13px;
    }
    .border td
    {
        border: 1px solid #000000;
        border-collapse: collapse;
    }
    .border2 th
    {
        background-image: url(../../images/cs_bg.jpg);
        background-repeat: repeat-x;
        padding: 10px;
        color: White;
        text-transform: capitalize;
    }
    .submit
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px 0px;
        border: none;
    }
    .submit:hover
    {
        background-color: White;
        background-image: url(../../App_Themes/ikandi/images/submit.jpg);
        background-repeat: no-repeat;
        width: 105px;
        height: 28px;
        background-position: 0px -28px;
    }
    .header-top-sec
    {
        font-size: 15px;
        text-align: center;
        color: #e7e4fb;
        font-family: verdana;
        font-weight: 500;
        padding: 4px 0px;
        background-color: #405D99;
        text-transform: capitalize;
    }
    .main-table-head
    {
        table-layout: fixed;
        background: #fff;
        font-family: Verdana;
        font-size: 12px;
    }
    .main-table-head th
    {
        background-color: #405D99;
        color: #fff;
        text-transform: capitalize;
        padding: 5px 0px;
    }
    .main-table-head td
    {
        padding: 2px 0px;
    }
    .hour-sele select
    {
        width: 90% !important;
        font-size: 11px;
        text-transform: uppercase;
        vertical-align: top;
    }
    select, input, option
    {
        font-size: 11px;
        vertical-align: top;
        color:Blue;
        
    }
    input[type="text"]
    {
        color:Blue;
        width:96% !important;
     }
    .hour-sele
    {
        text-align: center;
    }
    
    img
    {
        border: none;
    }
    .AddClass_Table td
    {
       padding: 3px 3px !important;
      }
</style>
<link href="../../css/report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">



    var start_times = "";
    var end_times = "";

    var startdiff = "";
    var enddiff = "";

    var IsUpdate = true;
    var Is_slotexist = "NOTEXISTS";

    function Is_slotexist_fnc(elem) {

        var Ids = elem.id;
        var cId = Ids.split("_")[6].substr(3);

        var slotname = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtslotname" + "']").val();
        var id = parseInt($("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_hdnID" + "']").val());

        //var resulta = "";
        try {

            proxy.invoke("SlotExistCheck", { SlotName: slotname, SlotID: id }, function (result) {
                if (result == "NOTEXISTS") {
                    Is_slotexist = "NOTEXISTS";
                    Updateslotadmin(elem);
                    return true;
                }
                else if (result == "EXISTS") {
                    Is_slotexist = "EXISTS";
                    alert("slot name already exist :" + " " + slotname);
                    elem.value = elem.defaultValue;
                    return false;
                }

            }, onPageError, false, false);

        }

        catch (err) {
            alert(err.message);
        }


    }

    function Updateslotadmin(elem) {

        try {
            var Ids = elem.id;
            var cId = Ids.split("_")[6].substr(3);
            var controlName = Ids.split("_")[7].substr(0);
            var userId = '<%=this.UserId%>';

            var slotname = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtslotname" + "']").val();
            var slottype = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddltypesofslot" + "']").val();

            var id = parseInt($("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_hdnID" + "']").val());
            //var housrdiff = (parseInt(((enddiff.getMinutes() - startdiff.getMinutes()) / 1000 / 3600) * 100, 10)) / 100;
            // checkForm(elem);
            var Starttime_hh = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlstatHH" + "']").val();
            var Strattime_mm = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlStatMin" + "']").val();
            var Endtime_hh = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_dllendtimehh" + "']").val();
            var Endtime_mm = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlendmin" + "']").val();

            var StartTime = Starttime_hh + ":" + Strattime_mm;
            var Endtime = Endtime_hh + ":" + Endtime_mm;

            var IsValidtme = Validate_tim(StartTime, Endtime)
            if (IsValidtme == false) {
                alert('star time and end time could not be greater then 24');

                window.location.href = "FrmSlotAdmin.aspx";
                return;

            }

            var startt_time = new Date("November 13, 2013 " + StartTime);
            startdiff = startt_time;
            start_times = startt_time.getTime();

            var End_times = new Date("November 13, 2013 " + Endtime);
            enddiff = End_times;
            end_times = End_times.getTime();




            var housrdiff = (enddiff.getTime() - startdiff.getTime()) / 60000;
            var defSec = parseInt(housrdiff)

            if (housrdiff == 30 || housrdiff == 60) {
                if (start_times != "" && end_times != "") {

                    if (start_times > end_times) {
                        alert('Start-time must be smaller then End-time');

                        window.location.href = "FrmSlotAdmin.aspx";

                        $('#<%= btn_submit.ClientID %>').trigger("click");
                        // elem.value = elem.defaultValue;
                        return false;
                    }

                }

            }
            else {

                alert('Slot time cannot exceed 1 hr or 30 minutes');
                //elem.value = elem.defaultValue;

                window.location.href = "FrmSlotAdmin.aspx";
                $('#<%= btn_submit.ClientID %>').trigger("click");

                return false;
            }

            if (start_times == end_times) {
                alert('Start-time and End-time cannot be same');

                window.location.href = "FrmSlotAdmin.aspx";
                $('#<%= btn_submit.ClientID %>').trigger("click");
                // elem.value = elem.defaultValue;
                return false;
            }
            if (slotname.length == 0) {
                alert('Slot name could not be empty.!');
                $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_txtslotname" + "']").focus();
                window.location.href = "FrmSlotAdmin.aspx";
                $('#<%= btn_submit.ClientID %>').trigger("click");
                return false;

            }
            if (Starttime_hh == "-1") {
                alert('Please select start time');

                return false;

            }
            if (Endtime_hh == "-1") {
                alert('Please Select end time');

                return false;
            }
            if (controlName == "ddltypesofslot" || controlName == "dllendtimehh" || controlName == "ddlendmin") {
                Is_slotexist = "NOTEXISTS";

            }

            if (Is_slotexist == "NOTEXISTS") {

                proxy.invoke("Updateslotadmin", { SlotName: slotname, TypeOfSlot: slottype, start_HH: Starttime_hh, start_MM: Strattime_mm, End_HH: Endtime_hh, End_MM: Endtime_mm, id: id }, function (result) {
                    DisplayErrorMsg(result, elem);

                }, onPageError, false, false);

            }
        }
        catch (err) {
            alert(err.message);
        }

    }






    function Validate_tim(startime, endtime) {
        var split_hh = startime.split(':');
        var endtime_hh = endtime.split(':');

        var s_hh = parseInt(split_hh[0]);
        var s_mm = parseInt(split_hh[1]);

        if (s_hh == 24) {
            if (s_mm == 00) {
                return true;
            }
            else {
                return false;
            }

        }
        var e_hh = parseInt(endtime_hh[0]);
        var e_mm = parseInt(endtime_hh[1]);

        if (e_hh == 24) {
            if (e_mm == 00) {
                return true;
            }
            else {
                return false;
            }

        }
    }
    function DisplayErrorMsg(Result, elem) {

        var Ids = elem.id;
        var cId = Ids.split("_")[6].substr(3);
        var controlName = Ids.split("_")[7].substr(0);

        var defValue = elem.defaultValue;

        if (Result == 'STARTTIMEEXITS') {

            // var defValue = elem.defaultValue;
            window.location.href = "FrmSlotAdmin.aspx";
            alert('slot start time already taken by another slot ');

            $('#<%= btn_submit.ClientID %>').trigger("click");

            return false;
        }
        else if (Result == 'ENDTIMEEXITS') {

            // var defValue = elem.defaultValue;

            alert('slot end time already taken by another slot');

            window.location.href = "FrmSlotAdmin.aspx";
            $('#<%= btn_submit.ClientID %>').trigger("click");

            return false;
        }
        else if (Result == 'UPDATED') {

            // var defValue = elem.defaultValue;

            //alert('Record updated');

            //window.location.href = "FrmSlotAdmin.aspx";
            $('#<%= btn_submit.ClientID %>').trigger("click");

            return false;
        }
        else {

            // var defValue = elem.defaultValue;

            alert('slot start time and end  could not be same');

            window.location.href = "FrmSlotAdmin.aspx";
            //$('#<%= btn_submit.ClientID %>').trigger("click");

            return false;
        }
    }




    function checkForm(elem) {

        try {
            var start_time;

            var end_time;

            var Ids = elem.id;
            var cId = Ids.split("_")[6].substr(3);
            var controlName = Ids.split("_")[7].substr(0);
            var am_pm;
            var hh;
            var mm;
            var val = $("#<%= grdslot.ClientID %> input[id*='ctl" + cId + "_" + controlName + "']").val();

            var Starttime_hh = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlstatHH" + "']").val();
            var Strattime_mm = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlStatMin" + "']").val();
            var Endtime_hh = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_dllendtimehh" + "']").val();
            var Endtime_mm = $("#<%= grdslot.ClientID %> select[id*='ctl" + cId + "_ddlendmin" + "']").val();

            var StartTime = starttime_hh + ":" + Strattime_mm;
            var Endtime = Endtime_hh + ":" + Endtime_mm;


            var startt_time = new Date("November 13, 2013 " + StartTime);
            startdiff = startt_time;
            start_times = startt_time.getTime();

            var End_times = new Date("November 13, 2013 " + Endtime);
            enddiff = End_times;
            end_times = startt_time.getTime();
        }
        catch (err) {
            alert(err.message);
        }

    }

    function onlyAlphabets(e, t) {
        //        try {
        //            if (window.event) {
        //                var charCode = window.event.keyCode;
        //            }
        //            else if (e) {
        //                var charCode = e.which;
        //            }
        //            else { return true; }
        //            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
        //                return true;
        //            else
        //                ShowHideMessageBox(true, 'Allowing only alphabets', 'Slot admin');
        //            return false;
        //        }
        //        catch (err) {
        //            alert(err.Description);
        //        }
    }


    function isNumberKey(e, obj) {

        //        var charCode;
        //        if (e.keyCode > 0) {
        //            charCode = e.which || e.keyCode;
        //        }
        //        else if (typeof (e.charCode) != "undefined") {
        //            charCode = e.which || e.keyCode;
        //        }
        //      
        //        if (charCode>=48 && charCode<=58) {
        //            
        //            return true;

        //        }
        //        else {
        //            return false;
        //        }



    }
    var IsShiftDown = false;
    function BlockingHtml(Sender, e) {
        var key = e.which ? e.which : e.keyCode;
        if (key == 16) {
            IsShiftDown = true;
            //CharCounter(Sender, 10);
        }
        else if ((IsShiftDown == true) && ((key == 188) || (key == 190))) {
            return false;
        }
    }
</script>
<div style="width:100%">
    <table border="0" align="center" cellpadding="0" cellspacing="0" style="width:800px;margin:0 auto">
    <tr>
        <td>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="header-top-sec">
                        Slot Admin
                    </td>
                </tr>
                <%--<tr>
                    <td>--%>
                       <%-- <table width="100%" border="0" align="center" cellspacing="0" cellpadding="0" style="margin: 0px;">
                            <tr class="">
                            </tr>
                            <tr>
                            </tr>
                        </table>
                        <table width="100%" border="0" class="AddClass_Table" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="padding-bottom: 10px;">
                                                <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;">
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>--%>
                            <tr>
                                <td valign="top">
                                    <!--table2-->
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="main-table-head">
                                        <tr>
                                            <td align="left">
                                                <asp:UpdatePanel ID="InsertEmployeeUpdatePanel" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdslot" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            ShowFooter="true" HeaderStyle-Height="30px" HeaderStyle-HorizontalAlign="Center"
                                                            OnRowDataBound="grdslot_RowDataBound" OnRowCommand="grdslot_RowCommand" CssClass="AddClass_Table">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="20%" HeaderText="Slot Name">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtslotname" onkeydown="return BlockingHtml(this,event);" ToolTip="update slot name here"
                                                                            CssClass="inputvalue_textbox" MaxLength="50" onchange="Is_slotexist_fnc(this)"
                                                                            Text='<%#Eval("SlotName") %>' runat="server"></asp:TextBox>
                                                                        <asp:HiddenField runat="server" ID="hdnID" Value='<%#Eval("SlotID") %>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtslotnameFooter" ToolTip="add new slot name" onkeydown="return BlockingHtml(this,event);"
                                                                            MaxLength="50" runat="server"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <FooterStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="type of slot" ItemStyle-Width="150px" ItemStyle-CssClass="hour-sele">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddltypesofslot" runat="server" onchange="Updateslotadmin(this)">
                                                                            <asp:ListItem Value="1" Text="Normal Hours"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="OT1"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="OT2"></asp:ListItem>
                                                                            <asp:ListItem Value="4" Text="OT3"></asp:ListItem>
                                                                            <asp:ListItem Value="5" Text="OT4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField runat="server" ID="hdnDesignationItem" Value='<%#Eval("TypeOfSlot") %>' />
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div class="hour-sele">
                                                                            <asp:DropDownList ID="ddltypesofslotFooter" runat="server" AppendDataBoundItems="true">
                                                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="Normal Hours"></asp:ListItem>
                                                                                <asp:ListItem Value="2" Text="OT1"></asp:ListItem>
                                                                                <asp:ListItem Value="3" Text="OT2"></asp:ListItem>
                                                                                <asp:ListItem Value="4" Text="OT3"></asp:ListItem>
                                                                                <asp:ListItem Value="5" Text="OT4"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="Start time" ItemStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ToolTip="stat time hours" ID="ddlstatHH" Style="width: 50%;" runat="server">
                                                                                <asp:ListItem Value="-1" Selected="True">select</asp:ListItem>
                                                                                <%--<asp:ListItem Value="00">00</asp:ListItem>--%>
                                                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                                                <asp:ListItem Value="09">09</asp:ListItem>
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
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ToolTip="end time Hours" ID="ddlStatMin" runat="server" Style="width: 40%;">
                                                                                <%--<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                                                <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                                <asp:ListItem Value="35">35</asp:ListItem>
                                                                                <asp:ListItem Value="40">40</asp:ListItem>
                                                                                <asp:ListItem Value="45">45</asp:ListItem>
                                                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                                                <asp:ListItem Value="55">55</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator_statHors" ControlToValidate="ddlstatHH" InitialValue="-1" runat="server" ErrorMessage="Please select start Hours"></asp:RequiredFieldValidator>--%>
                                                                            <asp:HiddenField ID="hdnstarthousrs" runat="server" Value='<%#Eval("StartHrs") %>' />
                                                                            <asp:HiddenField ID="hdnstartMin" runat="server" Value='<%#Eval("StartMin") %>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ToolTip="stat_time hours" ID="ddlstatHH_foter" Style="width: 50%;"
                                                                                runat="server">
                                                                                <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                                                <asp:ListItem Value="09">09</asp:ListItem>
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
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ToolTip="end time Hours" ID="ddlStatMin_foter" Style="width: 40%;"
                                                                                runat="server">
                                                                                <%--<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                                                <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                                <asp:ListItem Value="35">35</asp:ListItem>
                                                                                <asp:ListItem Value="40">40</asp:ListItem>
                                                                                <asp:ListItem Value="45">45</asp:ListItem>
                                                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                                                <asp:ListItem Value="55">55</asp:ListItem>
                                                                                <%-- <asp:ListItem Value="60">60</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_statHors_foter" ControlToValidate="ddlstatHH_foter" InitialValue="-1" runat="server" ErrorMessage="Please select start Hours" style="display:none;"></asp:RequiredFieldValidator>--%>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-CssClass="border" HeaderText="End Time" ItemStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ToolTip="End time hours" ID="dllendtimehh" Style="width: 50%;"
                                                                                runat="server" onchange="Updateslotadmin(this)">
                                                                                <%--<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                                                <asp:ListItem Value="09">09</asp:ListItem>
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
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ToolTip="End time Min" ID="ddlendmin" Style="width: 40%;" runat="server"
                                                                                onchange="Updateslotadmin(this)">
                                                                                <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                                <asp:ListItem Value="35">35</asp:ListItem>
                                                                                <asp:ListItem Value="40">40</asp:ListItem>
                                                                                <asp:ListItem Value="45">45</asp:ListItem>
                                                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                                                <asp:ListItem Value="55">55</asp:ListItem>
                                                                                <%-- <asp:ListItem Value="60">60</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <asp:HiddenField ID="hdnendhh" runat="server" Value='<%#Eval("EndHrs") %>' />
                                                                            <asp:HiddenField ID="hdnendmin" runat="server" Value='<%#Eval("EndMin") %>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:DropDownList ToolTip="End time hours" ID="ddlendHH_foter" Style="width: 50%;"
                                                                                runat="server">
                                                                                <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                                                <asp:ListItem Value="09">09</asp:ListItem>
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
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ToolTip="End time min" ID="ddlendMin_foter" Style="width: 40%;"
                                                                                runat="server">
                                                                                <%--<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                                                <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                <asp:ListItem Value="25">25</asp:ListItem>
                                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                                <asp:ListItem Value="35">35</asp:ListItem>
                                                                                <asp:ListItem Value="40">40</asp:ListItem>
                                                                                <asp:ListItem Value="45">45</asp:ListItem>
                                                                                <asp:ListItem Value="50">50</asp:ListItem>
                                                                                <asp:ListItem Value="55">55</asp:ListItem>
                                                                                <%-- <asp:ListItem Value="60">60</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator_endHH_foter" ControlToValidate="ddlendHH_foter"  InitialValue="-1" runat="server" ErrorMessage="Please select end Hours" style="display:none;"></asp:RequiredFieldValidator>--%>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="5px">
                                                                    <FooterTemplate>
                                                                        <div style="text-align: center;">
                                                                            <asp:LinkButton ID="abtnAdd" ValidationGroup="time1" runat="server" CommandName="Insert"
                                                                                CssClass="link" Text="Add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'>
                                                                        <img src="../../images/add-butt.png"  />
                                                                        
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                    <ControlStyle Width="20%"></ControlStyle>
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <FooterStyle CssClass="border" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" class="main-table-head"
                                                                    bordercolor="#ccc" style="border-collapse: collapse; table-layout: fixed;">
                                                                    <thead>
                                                                        <tr style="text-align: center;">
                                                                            <th style="width: 20%">
                                                                                Slot Name
                                                                            </th>
                                                                            <th style="width: 20%">
                                                                                Type of slot
                                                                            </th>
                                                                            <th style="width: 27%">
                                                                                Start Time
                                                                            </th>
                                                                            <th style="width: 27%">
                                                                                End Time
                                                                            </th>
                                                                            <th style="width: 5%">
                                                                                &nbsp;
                                                                            </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center" style="width: 20%">
                                                                                <asp:TextBox ID="txtslotnameempty_addnew" Style="text-align: center;" CssClass="inputvalue_textbox"
                                                                                    Width="90%" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 20%" align="center">
                                                                                <asp:DropDownList ID="ddltypesofslotEmpty_addnew" Style="width: 90%" runat="server">
                                                                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                                                                    <asp:ListItem Value="1" Text="Normal Hours"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="OT1"></asp:ListItem>
                                                                                    <asp:ListItem Value="3" Text="OT2"></asp:ListItem>
                                                                                    <asp:ListItem Value="4" Text="OT3"></asp:ListItem>
                                                                                    <asp:ListItem Value="5" Text="OT4"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="width: 27%" align="center">
                                                                                <asp:DropDownList ToolTip="stat_time hours" ID="ddlstatHH_empty" Style="width: 50%"
                                                                                    runat="server">
                                                                                    <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                                                    <asp:ListItem Value="09">09</asp:ListItem>
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
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_statHors_empty" ControlToValidate="ddlstatHH_empty"
                                                                        InitialValue="-1" runat="server" ErrorMessage="Please select start Hours"></asp:RequiredFieldValidator>--%>
                                                                                <asp:DropDownList ToolTip="start time Min" ID="ddlStatMin_empty" Style="width: 40%"
                                                                                    runat="server">
                                                                                    <%--<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                                                    <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                                    <asp:ListItem Value="35">35</asp:ListItem>
                                                                                    <asp:ListItem Value="40">40</asp:ListItem>
                                                                                    <asp:ListItem Value="45">45</asp:ListItem>
                                                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                                                    <asp:ListItem Value="55">55</asp:ListItem>
                                                                                    <%--<asp:ListItem Value="60">60</asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="center" style="width: 27%">
                                                                                <asp:DropDownList ToolTip="End time hours" ID="ddlendtimehh_empty" Style="width: 50%"
                                                                                    runat="server">
                                                                                    <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                                                    <asp:ListItem Value="09">09</asp:ListItem>
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
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlstatHH_empty"
                                                                        InitialValue="-1" runat="server" ErrorMessage="Please select start Hours"></asp:RequiredFieldValidator> --%>
                                                                                <asp:DropDownList ToolTip="End time Min" ID="ddlendtimemMm_empty" Style="width: 40%"
                                                                                    runat="server">
                                                                                    <%--<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>--%>
                                                                                    <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                                    <asp:ListItem Value="35">35</asp:ListItem>
                                                                                    <asp:ListItem Value="40">40</asp:ListItem>
                                                                                    <asp:ListItem Value="45">45</asp:ListItem>
                                                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                                                    <asp:ListItem Value="55">55</asp:ListItem>
                                                                                    <%--<asp:ListItem Value="60">60</asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="width: 5%" align="center">
                                                                                <asp:LinkButton ID="addbutton" runat="server" ToolTip="Insert new slot record" CommandName="addnew"
                                                                                    CssClass="link" Text="" ValidationGroup="time2" OnClientClick="">


                                                                         <img src="../../images/add-butt.png"  / alt="Add">

                                                                                </asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle Height="23px" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Button ID="btn_submit" runat="server" Visible="false" OnClick="btn_submit_Click" />
                                </td>
                            </tr>
                        </table>
                 <%--   </td>
                </tr>
            </table>--%>
        </td>
    </tr>
</table>
</div>