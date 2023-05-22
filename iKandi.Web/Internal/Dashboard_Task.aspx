<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="false" 
    CodeBehind="Dashboard_Task.aspx.cs" Inherits="iKandi.Web.Internal.Dashboard_Task" %>

<%@ Register Src="../UserControls/Forms/UserAccountInformation.ascx" TagName="UserAccountInformation"
    TagPrefix="uc" %>

<%--<%@ Register Src="../UserControls/Lists/CommingUpHolidays.ascx" TagName="CommingUpHolidays"
    TagPrefix="uc" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../js/menu-collapsed.js" type="text/javascript"></script>
   <script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/new-style.css" />
    <script type="text/javascript">
        function hidePanels(id) {
            var fruits = [2, 3, 4, 5, 6];
            for (i = 0; i < fruits.length; i++) {
                if (fruits[i] != id) {
                    $(".panelcontent" + fruits[i]).hide();
                }
            }
            $('#mytask_submenu').hide();
            $('#mytask_submenu2').hide();
        }
        
        $(document).ready(function () {
            $("#account").addClass("border"); 
        }); </script>
    <script type="text/javascript">        $(function () {
            $('html').click(function () {
                $('#div1').slideUp();
            }); $("#click_here").mouseover(function (event) {
                event.preventDefault(); $("#div1").slideDown();
            });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#costing').click(function () {
                $('.panelcontent1').slideToggle();
//                $('.panelcontent3').hide(); 
//                $('.panelcontent2').hide();
//                $('.panelcontent4').hide();
//                $('#mytask_submenu').hide(); 
//                $('#mytask_submenu2').hide();
            });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#Tasks').click(function () {
                $('.panelcontent2').slideToggle();
                hidePanels(2);
                //$('.panelcontent6').hide();
                //$('.panelcontent1').hide();
                $('#designcontent').hide();
                $('#merchandisingcontent').hide();
                $('#fabriccontent').hide();
                $('#accessoriescontent').hide();
                $('#technicalcontent').hide();
                $('#productioncontent').hide();
                $('#QAcontent').hide();
                $('#logisticcontent').hide();
                $('#financecontent').hide();
                $('#salescontent').hide();
            }); $('#mytask').click(function () {
                $('#mytask_submenu').slideToggle();
                $('#mytask_submenu2').hide();
                $('#merchandisingcontent').hide();
                $('#fabriccontent').hide();
                $('#accessoriescontent').hide();
                $('#technicalcontent').hide();
                $('#productioncontent').hide();
                $('#QAcontent').hide();
                $('#logisticcontent').hide();
                $('#financecontent').hide();
                $('#salescontent').hide();
            });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('.teamtask').click(function () {
                var show = $(this).next('.teamsubtask').is(":visible");
                if (show)
                    $(this).next('.teamsubtask').slideUp('fast');
                $('.teamsubtask').hide();
                if (!show)
                    $(this).next('.teamsubtask').slideDown('fast')
            });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#finance').click(function () {
                $('#financecontent').slideToggle(); $('#merchandisingcontent').hide(); $('#designcontent').hide();
                $('#salescontent').hide(); $('#fabriccontent').hide(); $('#accessoriescontent').hide();
                $('#technicalcontent').hide(); $('#productioncontent').hide(); $('#QAcontent').hide();
                $('#logisticcontent').hide();
            });
        }); </script>
    <script type="text/javascript">
        $(function () {
            $('#team').click(function () {
                $('.panelcontent4').slideToggle();
                hidePanels(4);
            });
            $('#holiday').click(function () {
                $('.panelcontent3').slideToggle();
                hidePanels(3);
                $('.panelcontent3').css("background-color", "#cccccc");
            });
            $('#bookingcalculator').click(function () {
                $('.panelcontent5').slideToggle();
                hidePanels(5);
            });
            $('#notification').click(function () {
                $('.panelcontent6').slideToggle();
                hidePanels(6);
            });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#holidayinfo').click(function () {
                $('#holidayinfo_submenu').slideToggle(); $('#granted_submenu').hide(); $('#holy_submenu').hide();
            });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#granted').click(function () {
                $('#granted_submenu').slideToggle(); $('#holidayinfo_submenu').hide(); $('#holy_submenu').hide();
            });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#holidaymenu').click(function ()
            { $('#holidaycontent').slideToggle(); $('#holidaycontent2').hide(); });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#holidayapprove').click(function ()
            { $('#holidaycontent2').slideToggle(); $('#holidaycontent').hide(); });
        }); </script>
    <script type="text/javascript">        $(function () {
            $('#holy').click(function () {
                $('#holy_submenu').slideToggle();
                $('#holidayinfo_submenu').hide(); $('#granted_submenu').hide();
            });
        }); </script>
    <script type="text/javascript">
//        var MyTaskCount = '<%=ltMyTask.ClientID%>';
//        var TotalTaskCount = '<%=ltTotalTaskCount.ClientID%>';
        $(function () {
            var ShowCosting = "<%=ShowCosting%>";
            var ShowBooking = "<%=ShowBooking%>";
            if (ShowCosting == "0") {
                $(".costingandenq").remove();
            }
            if (ShowBooking == "0") {
                $(".bookingcalc").remove();
            }
            $(".loadingimage").hide();
            $(".teamtaskloadingimage").hide();
        });
//        function LoadTeamTask() {// by shubhendu
//            debugger;
//            alert("check");
//            if ($("#loadteamtask").val() == "1")
//                return;
//            $("#loadteamtask").val("1");
//            GetTeamTaskCount();
//        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#teamtask').click(function () {
                debugger;
                $('#mytask_submenu2').slideToggle();
                // $('#mytask_submenu').hide(); BY shubhendu
            });
            $('#Tasks').click();
            $('#mytask').click();
            $('#costing').click();
        });
    </script>
    <style type="text/css">
    #secure_footer
    {
        position:absolute;
        bottom:0px;
    }
    .secure_center_contentWrapper {
    height: 100%;
   
}
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">

    <input type="hidden" id="loadteamtask" value="0" />
     <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td id="account" width="30%" valign="top">
                <ul class="menuc" style="width: 100%">
                    <li><a href="#">Account Information</a>
                        <ul class="common" style="width: 100%">
                            <li>
                                <div style="border: solid 1px #ccc; background-color: #f2f2f2;">
                                    <uc:UserAccountInformation ID="UserAccountInformation1" runat="server" />
                                </div>
                            </li>
                        </ul>
                    </li>
                </ul>
                <div class="panel1 costingandenq">
                    <div id="costing" class="heading">
                        <nobr>Costing and Enquiries</nobr>
                    </div>
                    <div class="panelcontent1">
                        <<%--div align="center">
                            <uc:costingandenquiries Visible="false" ID="CostingAndEnquiries1" 
                                runat="server" />
                        </div>--%>
                    </div>
                </div>
                <div class="panel1 allTasks" style="display:none";>
                    <div id="Tasks" class="heading" style="width: auto">
                        <div style="float: left" align="left">
                            Tasks
                        </div>
                        <div style="float: right; padding-right: 0px;" align="right">
                            (<asp:Label ID="ltTotalTaskCount" runat="server" CssClass="TotalTaskCount" Text="0"></asp:Label>)
                        </div>
                    </div>
                    <div class="panelcontent2">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <div id="mytask" class="subheading" style="text-transform:none;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    My Tasks &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <%--<asp:Image ID="Image2" style="width:4%;" CssClass="mytaskloadingimage"  ImageUrl="~/App_Themes/ikandi/images1/loading29.gif" runat="server" />--%>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    (<asp:Label ID="ltMyTask" runat="server" Text="0" CssClass="MyTaskCount"></asp:Label>)
                                                </td>
                                            </tr>
                                        </table>
                                    </div> 
                                    <div id="mytask_submenu" class="AllMyTask mytask_submenu2">
                                        <asp:Repeater ID="rptMyTask" runat="server">
                                            <ItemTemplate>
                                                <div class="design2" onclick="JavaScript:GetMyTask(<%#Eval("TaskId") %>,this)">
                                                
                                                    <div style="float: left" align="left">
                                                        <a ID="alittask" runat="server" class="tooltipdb1" title='<%#Eval("Description") %>'><%#Eval("Task_Name") %></a>
                                                        <%--<asp:Literal ID="litTask" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>--%>
                                                    </div>
                                                    <div style="float: right; padding-right: 5px;" align="right">
                                                        (<asp:Literal ID="Literal1" runat="server" Text='<%#Eval("Task_Count") %>'></asp:Literal>)
                                                    </div>
                                                    &nbsp;
                                                </div>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                                <img src="../images/seperatorbar2.gif" alt="" width="98%" />
                                            </SeparatorTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div id="teamtask" class="subheading" style="text-transform:none;" onclick="JavaScript:LoadTeamTask();">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    Team Tasks &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Image ID="Image1"  CssClass="teamtaskloadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading128.gif"
                                                        runat="server" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    (<asp:Label ID="ltTeamTask" runat="server" Text="0" CssClass="TeamTaskcount"></asp:Label>)
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="mytask_submenu2" class="AllTeamTask mytask_submenu">
                                        <asp:Repeater ID="rptTeamTask" runat="server" OnItemDataBound="rptTeamTask_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="teamtask design">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <img src="../images/bullet2.jpg" alt="" /><asp:Literal ID="Literal2" runat="server"
                                                                    Text='<%#Eval("Dept_Name") %>'></asp:Literal>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="right" style="padding-right: 5px; font-weight: bold;">
                                                                (<asp:Literal ID="Literal4" runat="server" Text='<%#Eval("Task_Count") %>'></asp:Literal>)
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="teamsubtask content" align="left" style="float: left;">
                                                    <asp:Repeater ID="rptTeamSubTask" runat="server">
                                                        <ItemTemplate>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" onclick="JavaScript:GetTeamTask(<%#Eval("TaskId") %>)">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="Literal5" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#"("+Eval("Task_Designation")+")" %>'
                                                                            CssClass="designation" Style="padding-left: 10px;"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="right" style="padding-right: 5px; font-weight: bold;">
                                                                        (<asp:Literal ID="Literal6" runat="server" Text='<%#Eval("Task_Count") %>'></asp:Literal>)
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <SeparatorTemplate>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td>
                                                                        <img src="../images/seperatorbar.gif" alt="" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </SeparatorTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="panel1" style="display:none;">
                    <div id="holiday" class="heading">
                        Holiday</div>
                    <div class="panelcontent3">
                        <div id="holidayinfo" class="subheading">
                            Holiday Information</div>
                       <%-- <div id="holidayinfo_submenu" class="mytask_submenu">
                            <uc:leaveinformation ID="LeaveInformation1" runat="server" />
                        </div>--%>
                        <div id="granted" class="subheading">
                            Granted Holiday</div>
                        <div id="granted_submenu" class="holidaycontent">
                            <div class="holidaydesign">
                                <div>
                                    <%--<uc:grantedleaves ID="GrantedLeaves1" runat="server" />--%>
                                </div>
                            </div>
                        </div>
                        <div id="holy" class="subheading">
                            Holiday</div>
                       <%-- <div id="holy_submenu" class="holidaycontent" style="padding: 10px;" align="center">
                            <uc:holidaylist IsSmall="true" ID="HolidayList1" runat="server" />
                        </div>--%>
                    </div>
                </div>
                <%--<div class="panel1">
                    <div id="team" class="heading">
                        <nobr>Team Members</nobr>
                    </div>
                    <div class="panelcontent4">
                        <uc:TeamMembers ID="TeamMembers1" runat="server" />
                    </div>
                </div>--%>
                <div class="panel1 bookingcalc">
                    <div id="bookingcalculator" class="heading">
                        <nobr><%= (iKandi.Web.Components.ApplicationHelper.LoggedInUser.ClientData != null) ? "LEADTIME / DELIVERY DATE TABLE" : "Booking Calculator"%></nobr>
                    </div>
                    <div class="panelcontent5">
                        <%--<uc:bookingcalculator ID="BookingCalculator1" runat="server" />--%>
                    </div>
                </div>
                <div class="panel1 notification" runat="server" style="display:none;">
                    <div id="notification" class="heading" width="100%">
                        <nobr><strong>Notification</strong> (Task Closed on Status Meeting file)</nobr>
                    </div>
                   <%-- <div class="panelcontent6">
                        <uc:ClosedResolutionTask ID="ClosedResolutionTask" runat="server" />
                    </div>--%>
                </div>
                </td>
                <td width="78%" valign="top">
                
                    <div id="CentralDiv">
                    </div>
                    <div style="width: 98.5%; margin-left: 10px; margin-top:30px; display:none;" id="div_li0" class="cdiv"">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                           <%-- <tr>
                                <th style="text-align: left; color: #FFFFFF; padding: 0.5em; font: bold 11px/14px Arial;
                                    background:#39589c;">
                                    Upcoming Holidays / Events
                                </th>
                            </tr>--%>
                            <tr>
                                <td valign="top">
                                 <%--   <uc:commingupholidays ID="CommingUpHolidays1" runat="server" />--%>
                                </td>
                            </tr>
                            <tr>
                           <%-- <td>
                            <uc:hitratefordesignersreport Visible="true" ID="HitRateForDesignersReport1" 
                                    runat="server" />
                            </td>--%>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li1" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Create PO: <span style="color: #0000FF;">3 (1 Greige, 1 Against Orders, 1 Sampling)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="12%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="15%" style="background: #e4ebf2;">
                                                Buyer
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Serial No.
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Contract
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Style No.
                                            </td>
                                            <td width="6%" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="12%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Greige
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                AO 101
                                            </td>
                                            <td>
                                                ER 22301
                                            </td>
                                            <td>
                                                TP 30367 b
                                            </td>
                                            <td>
                                                4768 m
                                            </td>
                                            <td>
                                                20 Feb 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Create PO</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Against Orders
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Debenhams
                                            </td>
                                            <td>
                                                AO 102
                                            </td>
                                            <td>
                                                ER 22302
                                            </td>
                                            <td>
                                                TP 30368 C
                                            </td>
                                            <td>
                                                900 pcs.
                                            </td>
                                            <td>
                                                21 Feb 12 (Tue)
                                            </td>
                                            <td>
                                                <a href="#">Create PO</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Sampling
                                            </td>
                                            <td>
                                                Lace
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                AO 103
                                            </td>
                                            <td>
                                                ER 22303
                                            </td>
                                            <td>
                                                TP 30369 E
                                            </td>
                                            <td>
                                                200 m
                                            </td>
                                            <td>
                                                23 Feb 12 (Thu)
                                            </td>
                                            <td>
                                                <a href="#">Create PO</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li2" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px Arial;
                                    background: #e4ebf2;">
                                    PO Approval: <span style="color: #0000FF;">4 (2 Greige, 1 Against Orders, 1 Sampling)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="12%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="15%" style="background: #e4ebf2;">
                                                Buyer
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Serial No.
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Contract#
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Style No.
                                            </td>
                                            <td width="6%" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="12%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Greige
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                Next
                                            </td>
                                            <td>
                                                AO 101
                                            </td>
                                            <td>
                                                ER 22301
                                            </td>
                                            <td>
                                                AP 20367 S
                                            </td>
                                            <td>
                                                2368 m
                                            </td>
                                            <td>
                                                20 Feb 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">PO Confirmation</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Greige
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                AO 102
                                            </td>
                                            <td>
                                                ER 22301
                                            </td>
                                            <td>
                                                AP 20367 S
                                            </td>
                                            <td>
                                                2368 m
                                            </td>
                                            <td>
                                                20 Feb 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">PO Confirmation</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Against Orders
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Debenhams
                                            </td>
                                            <td>
                                                AW 202
                                            </td>
                                            <td>
                                                ER 22302
                                            </td>
                                            <td>
                                                TP 30368 C
                                            </td>
                                            <td>
                                                900 pcs.
                                            </td>
                                            <td>
                                                21 Feb 12 (Tue)
                                            </td>
                                            <td>
                                                <a href="#">PO Confirmation</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Sampling
                                            </td>
                                            <td>
                                                Lace
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                AW 203
                                            </td>
                                            <td>
                                                ER 22303
                                            </td>
                                            <td>
                                                TP 30369 E
                                            </td>
                                            <td>
                                                200 m
                                            </td>
                                            <td>
                                                23 Feb 12 (Thu)
                                            </td>
                                            <td>
                                                <a href="#">PO Confirmation</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: none;" id="div_li3" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Create SRV
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami</span>
                                        with <span style="color: #006699;">1234</span> <span style="color: #000000;">against
                                        </span><span style="color: #006699;">BIPL/ABA/G/2029320 </span><span style="color: #000000;">
                                            at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">20000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami
                                            Traders</span> with <span style="color: #006699;">1234</span> <span style="color: #000000;">
                                                against </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                                    at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Baweja
                                            Text Fab</span> with <span style="color: #006699;">1234</span> <span style="color: #000000;">
                                                against </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                                    at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Kumar
                                            & Sons India Pvt. Ltd.</span> with <span style="color: #006699;">1234</span>
                                        <span style="color: #000000;">against </span><span style="color: #006699;">BIPL/ABA/G/1234
                                        </span><span style="color: #000000;">at</span> <span style="color: #006699;">C47</span><span
                                            style="color: #000000;">on </span><span style="color: #006699;">12 feb 2012</span>
                                        for<span style="color: #006699;"> Poly Georgette PRD 3023 GEO Print</span> with
                                        <span style="color: #006699;">2000m</span> by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Haniton
                                            World</span> with <span style="color: #006699;">1234</span> <span style="color: #000000;">
                                                against </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                                    at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami</span>
                                        with <span style="color: #006699;">1234</span> <span style="color: #000000;">against
                                        </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                            at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami</span>
                                        with <span style="color: #006699;">1234</span> <span style="color: #000000;">against
                                        </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                            at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami</span>
                                        with <span style="color: #006699;">1234</span> <span style="color: #000000;">against
                                        </span><span style="color: #006699;">BIPL/ABA/G/2029320 </span><span style="color: #000000;">
                                            at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">20000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami
                                            Traders</span> with <span style="color: #006699;">1234</span> <span style="color: #000000;">
                                                against </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                                    at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Baweja
                                            Text Fab</span> with <span style="color: #006699;">1234</span> <span style="color: #000000;">
                                                against </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                                    at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Kumar
                                            & Sons India Pvt. Ltd.</span> with <span style="color: #006699;">1234</span>
                                        <span style="color: #000000;">against </span><span style="color: #006699;">BIPL/ABA/G/1234
                                        </span><span style="color: #000000;">at</span> <span style="color: #006699;">C47</span><span
                                            style="color: #000000;">on </span><span style="color: #006699;">12 feb 2012</span>
                                        for<span style="color: #006699;"> Poly Georgette PRD 3023 GEO Print</span> with
                                        <span style="color: #006699;">2000m</span> by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Haniton
                                            World</span> with <span style="color: #006699;">1234</span> <span style="color: #000000;">
                                                against </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                                    at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami</span>
                                        with <span style="color: #006699;">1234</span> <span style="color: #000000;">against
                                        </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                            at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <div style="width: 100%; text-align: left; padding: 3px;">
                                        <span style="color: #000000;">Create SRV</span> for <span style="color: #006699;">Abrami</span>
                                        with <span style="color: #006699;">1234</span> <span style="color: #000000;">against
                                        </span><span style="color: #006699;">BIPL/ABA/G/1234 </span><span style="color: #000000;">
                                            at</span> <span style="color: #006699;">C47</span><span style="color: #000000;">on
                                        </span><span style="color: #006699;">12 feb 2012</span> for<span style="color: #006699;">
                                            Poly Georgette PRD 3023 GEO Print</span> with <span style="color: #006699;">2000m</span>
                                        by <span style="color: #006699;">16 feb 2012</span>
                                    </div>
                                    <!-- <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0"
bordercolor="#F0F0F0" rules="all" class="dashboard-holiday-app-tbl"> <tr> <td width="12%"
style="background:#e4ebf2;">Type</td> <td width="14%" style="background:#e4ebf2;">Item
Name</td> <td width="15%" style="background:#e4ebf2;">Buyer</td> <td width="9%"
style="background:#e4ebf2;">PO No.</td> <td width="6%" style="background:#e4ebf2;">Qty.</td>
<td width="10%" style="background:#e4ebf2;">Target</td> <td width="16%" style="background:#e4ebf2;">Action</td>
</tr> <tr> <td>Greige</td> <td>Cotton Lycra</td> <td>Next</td> <td>BIPL/SUP/SRV/0001</td>
<td>200 m</td> <td>22 Feb 12 (Wed)</td> <td><a href="#">SRV</a></td> </tr> <tr>
<td>Against Orders</td> <td>Button</td> <td>Debenhams</td> <td>BIPL/SUP/SRV/0002</td>
<td>1200 pcs.</td> <td>23 Feb 12 (Thu) </td> <td><a href="#">SRV</a></td> </tr>
<tr> <td>Sampling</td> <td>Zip</td> <td>ASOS</td> <td>BIPL/SUP/SRV/0003</td> <td>500
Pcs.</td> <td>23 Feb 12 (Thu) </td> <td><a href="#">SRV</a></td> </tr> </table>
-->
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li4" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px Arial;
                                    background: #e4ebf2;">
                                    Create Supplier Return Challan: <span style="color: #0000FF;">2 (1 Checking, 1 Quality)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="12%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="15%" style="background: #e4ebf2;">
                                                Supplier Name
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                PO No.
                                            </td>
                                            <td width="6%" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="10%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Checking
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                BIPL/SUP/RCH/2123
                                            </td>
                                            <td>
                                                2300 m
                                            </td>
                                            <td>
                                                25 Feb 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Return Challan</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Quality
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Debenhams
                                            </td>
                                            <td>
                                                BIPL/SUP/RCH/2124
                                            </td>
                                            <td>
                                                900 Pcs.
                                            </td>
                                            <td>
                                                27 Feb 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Return Challan</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li5" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Create Debit Note by Fabric Department: <span style="color: #0000FF;">2 (1 Baweja, 1
                                        Abirami)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Supplier Name
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Amount
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Debit Note No.
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Remarks
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="20%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                1,00,000
                                            </td>
                                            <td>
                                                BIPL/D/34029
                                            </td>
                                            <td>
                                                Hi put your renarks here.
                                            </td>
                                            <td>
                                                28 Feb 12 (Tue)
                                            </td>
                                            <td>
                                                <a href="#">Debit Note..</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Abirami
                                            </td>
                                            <td>
                                                2,00,000
                                            </td>
                                            <td>
                                                BIPL/D/34030
                                            </td>
                                            <td>
                                                Hi put your renarks here.
                                            </td>
                                            <td>
                                                29 Feb 12 (Wed)
                                            </td>
                                            <td>
                                                <a href="#">Debit Note..</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li6" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Approve Debit Note by Fabric Department: <span style="color: #0000FF;">2 (1 Baweja,
                                        1 Abirami)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Supplier Name
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Amount
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Debit Note No.
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Remarks
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="20%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                2,00,000
                                            </td>
                                            <td>
                                                BIPL/D/34031
                                            </td>
                                            <td>
                                                Hi put your renarks here.
                                            </td>
                                            <td>
                                                01 Mar 12 (Thu)
                                            </td>
                                            <td>
                                                <a href="#">Approve Debit Note</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Sampling
                                            </td>
                                            <td>
                                                3,00,000
                                            </td>
                                            <td>
                                                BIPL/D/34032
                                            </td>
                                            <td>
                                                Hi put your renarks here.
                                            </td>
                                            <td>
                                                02 Mar 12 (Fri)
                                            </td>
                                            <td>
                                                <a href="#">Approve Debit Note</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li7" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Debit Note Receipt by Finance Department: <span style="color: #0000FF;">2 (1 Baweja,
                                        1 Abirami)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Supplier Name
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Amount
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Debit Note No.
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Remarks
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="20%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                1,50,000
                                            </td>
                                            <td>
                                                BIPL/D/34034
                                            </td>
                                            <td>
                                                Hi put your renarks here.
                                            </td>
                                            <td>
                                                28 Feb 12 (Tue)
                                            </td>
                                            <td>
                                                <a href="#">ORDER FORM</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Abirami
                                            </td>
                                            <td>
                                                2,10,000
                                            </td>
                                            <td>
                                                BIPL/D/34035
                                            </td>
                                            <td>
                                                Hi put your renarks here.
                                            </td>
                                            <td>
                                                29 Feb 12 (Wed)
                                            </td>
                                            <td>
                                                <a href="#">ORDER FORM</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li8" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Do 4-Points Checking: <span style="color: #0000FF;">4 (1 Delayed, 1 Current Week - till
                                        Saturday, 1 Next Week, 1 Beyond)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Print/Color
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                PO No.
                                            </td>
                                            <td width="18%" align="center" style="background: #e4ebf2;">
                                                Available Qty. for Check
                                            </td>
                                            <td width="10%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="17%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Delayed
                                            </td>
                                            <td>
                                                Button
                                            </td>
                                            <td>
                                                Red
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0001
                                            </td>
                                            <td>
                                                2000 Pcs.
                                            </td>
                                            <td>
                                                05 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Checking</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Current Week
                                            </td>
                                            <td>
                                                Lycra
                                            </td>
                                            <td>
                                                22098
                                            </td>
                                            <td>
                                                BIPL/SUP/FQA/0001
                                            </td>
                                            <td>
                                                300 m
                                            </td>
                                            <td>
                                                06 Mar 12 (Tue)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Checking</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Next Week
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Black
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0002
                                            </td>
                                            <td>
                                                2300 Pcs..
                                            </td>
                                            <td>
                                                07 Mar 12 (Wed)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Checking</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Beyond
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Black
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0003
                                            </td>
                                            <td>
                                                1100 Pcs.
                                            </td>
                                            <td>
                                                08 Mar 12 (Thu)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Checking</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li9" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    4- Points Checking Approval by QA: <span style="color: #0000FF;">4 (1 Delayed, 1 Current
                                        Week - till Saturday, 1 Next Week, 1 Beyond)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="10%" rowspan="2" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="9%" rowspan="2" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="8%" rowspan="2" style="background: #e4ebf2;">
                                                Print/Color
                                            </td>
                                            <td width="15%" rowspan="2" style="background: #e4ebf2;">
                                                PO No.
                                            </td>
                                            <td colspan="4" align="center" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="11%" rowspan="2" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="17%" rowspan="2" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="7%" align="center" style="background: #e4ebf2;">
                                                Available
                                            </td>
                                            <td width="8%" align="center" style="background: #e4ebf2;">
                                                Rejected
                                            </td>
                                            <td width="8%" align="center" style="background: #e4ebf2;">
                                                Returned
                                            </td>
                                            <td width="7%" align="center" style="background: #e4ebf2;">
                                                Debited
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Delayed
                                            </td>
                                            <td>
                                                Button
                                            </td>
                                            <td>
                                                Blue
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0001
                                            </td>
                                            <td>
                                                3000 pcs.
                                            </td>
                                            <td>
                                                200 pcs.
                                            </td>
                                            <td>
                                                200 pcs.
                                            </td>
                                            <td>
                                                200 pcs.
                                            </td>
                                            <td>
                                                10 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by QA</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Current Week
                                            </td>
                                            <td>
                                                Beeds
                                            </td>
                                            <td>
                                                Red
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0002
                                            </td>
                                            <td>
                                                5000 pcs.
                                            </td>
                                            <td>
                                                500 Pcs.
                                            </td>
                                            <td>
                                                500 pcs.
                                            </td>
                                            <td>
                                                500 pcs.
                                            </td>
                                            <td>
                                                12 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by QA</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Next Week
                                            </td>
                                            <td>
                                                Button
                                            </td>
                                            <td>
                                                White
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0003
                                            </td>
                                            <td>
                                                2000 pcs.
                                            </td>
                                            <td>
                                                100 pcs.
                                            </td>
                                            <td>
                                                100 pcs.
                                            </td>
                                            <td>
                                                100 pcs.
                                            </td>
                                            <td>
                                                13 Mar 12 (Tue)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by QA</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Beyond
                                            </td>
                                            <td>
                                                Polyster
                                            </td>
                                            <td>
                                                22321
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0004
                                            </td>
                                            <td>
                                                1000 m
                                            </td>
                                            <td>
                                                100 m
                                            </td>
                                            <td>
                                                100 m
                                            </td>
                                            <td>
                                                100 m
                                            </td>
                                            <td>
                                                14 Mar 12 (Wed)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by QA</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li10" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    4- Points Checking Approval by Fabric Manager: <span style="color: #0000FF;">4 (1 Delayed,
                                        1 Current Week - till Saturday, 1 Next Week, 1 Beyond)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="10%" rowspan="2" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="9%" rowspan="2" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="8%" rowspan="2" style="background: #e4ebf2;">
                                                Print/Color
                                            </td>
                                            <td width="13%" rowspan="2" style="background: #e4ebf2;">
                                                PO No.
                                            </td>
                                            <td colspan="4" align="center" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="10%" rowspan="2" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="20%" rowspan="2" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="7%" align="center" style="background: #e4ebf2;">
                                                Available
                                            </td>
                                            <td width="8%" align="center" style="background: #e4ebf2;">
                                                Rejected
                                            </td>
                                            <td width="8%" align="center" style="background: #e4ebf2;">
                                                Returned
                                            </td>
                                            <td width="7%" align="center" style="background: #e4ebf2;">
                                                Debited
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Delayed
                                            </td>
                                            <td>
                                                Button
                                            </td>
                                            <td>
                                                Blue
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0001
                                            </td>
                                            <td>
                                                3000 pcs.
                                            </td>
                                            <td>
                                                200 pcs.
                                            </td>
                                            <td>
                                                200 pcs.
                                            </td>
                                            <td>
                                                200 pcs.
                                            </td>
                                            <td>
                                                10 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by Fab. Mgr.</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Current Week
                                            </td>
                                            <td>
                                                Beeds
                                            </td>
                                            <td>
                                                Red
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0002
                                            </td>
                                            <td>
                                                5000 pcs.
                                            </td>
                                            <td>
                                                500 Pcs.
                                            </td>
                                            <td>
                                                500 pcs.
                                            </td>
                                            <td>
                                                500 pcs.
                                            </td>
                                            <td>
                                                12 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by Fab. Mgr.</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Next Week
                                            </td>
                                            <td>
                                                Button
                                            </td>
                                            <td>
                                                White
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0003
                                            </td>
                                            <td>
                                                2000 pcs.
                                            </td>
                                            <td>
                                                100 pcs.
                                            </td>
                                            <td>
                                                100 pcs.
                                            </td>
                                            <td>
                                                100 pcs.
                                            </td>
                                            <td>
                                                13 Mar 12 (Tue)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by Fab. Mgr.</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Beyond
                                            </td>
                                            <td>
                                                Polyster
                                            </td>
                                            <td>
                                                22321
                                            </td>
                                            <td>
                                                BIPL/SUP/AQA/0004
                                            </td>
                                            <td>
                                                1000 m
                                            </td>
                                            <td>
                                                100 m
                                            </td>
                                            <td>
                                                100 m
                                            </td>
                                            <td>
                                                100 m
                                            </td>
                                            <td>
                                                14 Mar 12 (Wed)
                                            </td>
                                            <td>
                                                <a href="#">4-Points Approval by Fab. Mgr.</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li11" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Create External Issue Challan: <span style="color: #0000FF;">2 (1 Processing, 1 Re-Processing)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="17%" style="background: #e4ebf2;">
                                                Print/Color
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                PO No.
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="17%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Processing
                                            </td>
                                            <td>
                                                Button
                                            </td>
                                            <td>
                                                White
                                            </td>
                                            <td>
                                                1000 Pcs.
                                            </td>
                                            <td>
                                                BIPL/SUP/CH/2123
                                            </td>
                                            <td>
                                                10 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">External Issue Challan</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Re-processing
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                2322
                                            </td>
                                            <td>
                                                12000 M
                                            </td>
                                            <td>
                                                BIPL/SUP/CH/2124
                                            </td>
                                            <td>
                                                12 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">External Issue Challan</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li12" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px Arial;
                                    background: #e4ebf2;">
                                    Issuance to Washing: <span style="color: #0000FF;">4 (1 Delayed, 1 Current Week - till
                                        Saturday, 1 Next Week, 1 Beyond)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Buyer
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Print/Color
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Serial No.
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Contract
                                            </td>
                                            <td width="8%" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="10%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Delayed
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Black
                                            </td>
                                            <td>
                                                SO 101
                                            </td>
                                            <td>
                                                AR 22301
                                            </td>
                                            <td>
                                                100 Pcs.
                                            </td>
                                            <td>
                                                15 Mar 12 (Thu)
                                            </td>
                                            <td>
                                                <a href="#">Issuance to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Current Week
                                            </td>
                                            <td>
                                                Deb
                                            </td>
                                            <td>
                                                100% Cotton
                                            </td>
                                            <td>
                                                2322
                                            </td>
                                            <td>
                                                SO 102
                                            </td>
                                            <td>
                                                AR 22301
                                            </td>
                                            <td>
                                                2000 m
                                            </td>
                                            <td>
                                                16 Mar 12 (Fri)
                                            </td>
                                            <td>
                                                <a href="#">Issuance to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Next Week
                                            </td>
                                            <td>
                                                Next
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                1231
                                            </td>
                                            <td>
                                                SW 202
                                            </td>
                                            <td>
                                                AR 22302
                                            </td>
                                            <td>
                                                1200 m
                                            </td>
                                            <td>
                                                17 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Issuance to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Beyond
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                Lycra
                                            </td>
                                            <td>
                                                2322
                                            </td>
                                            <td>
                                                SW 203
                                            </td>
                                            <td>
                                                AR 22303
                                            </td>
                                            <td>
                                                400 m
                                            </td>
                                            <td>
                                                19 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Issuance to Washing</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li13" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px Arial;
                                    background: #e4ebf2;">
                                    Receiving from Washing <span style="color: #0000FF;">4 (1 Delayed, 1 Current Week -
                                        till Saturday, 1 Next Week, 1 Beyond)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Buyer
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Print/Color
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Serial No.
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Contract
                                            </td>
                                            <td width="8%" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="10%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Delayed
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Black
                                            </td>
                                            <td>
                                                SO 101
                                            </td>
                                            <td>
                                                AR 22301
                                            </td>
                                            <td>
                                                100 Pcs.
                                            </td>
                                            <td>
                                                15 Mar 12 (Thu)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Current Week
                                            </td>
                                            <td>
                                                Deb
                                            </td>
                                            <td>
                                                100% Cotton
                                            </td>
                                            <td>
                                                2322
                                            </td>
                                            <td>
                                                SO 102
                                            </td>
                                            <td>
                                                AR 22301
                                            </td>
                                            <td>
                                                2000 m
                                            </td>
                                            <td>
                                                16 Mar 12 (Fri)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Next Week
                                            </td>
                                            <td>
                                                Next
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                1231
                                            </td>
                                            <td>
                                                SW 202
                                            </td>
                                            <td>
                                                AR 22302
                                            </td>
                                            <td>
                                                1200 m
                                            </td>
                                            <td>
                                                17 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Beyond
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                Lycra
                                            </td>
                                            <td>
                                                2322
                                            </td>
                                            <td>
                                                SW 203
                                            </td>
                                            <td>
                                                AR 22303
                                            </td>
                                            <td>
                                                400 m
                                            </td>
                                            <td>
                                                19 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li14" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px Arial;
                                    background: #e4ebf2;">
                                    Issuance to Cutting: <span style="color: #0000FF;">4 (1 Delayed, 1 Current Week - till
                                        Saturday, 1 Next Week, 1 Beyond)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Type
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Buyer
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Item Name
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Print/Color
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Serial No.
                                            </td>
                                            <td width="9%" style="background: #e4ebf2;">
                                                Contract
                                            </td>
                                            <td width="8%" style="background: #e4ebf2;">
                                                Qty.
                                            </td>
                                            <td width="10%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Delayed
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                Zip
                                            </td>
                                            <td>
                                                Black
                                            </td>
                                            <td>
                                                SO 101
                                            </td>
                                            <td>
                                                AR 22301
                                            </td>
                                            <td>
                                                100 Pcs.
                                            </td>
                                            <td>
                                                15 Mar 12 (Thu)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Current Week
                                            </td>
                                            <td>
                                                Deb
                                            </td>
                                            <td>
                                                100% Cotton
                                            </td>
                                            <td>
                                                2322
                                            </td>
                                            <td>
                                                SO 102
                                            </td>
                                            <td>
                                                AR 22301
                                            </td>
                                            <td>
                                                2000 m
                                            </td>
                                            <td>
                                                16 Mar 12 (Fri)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Next Week
                                            </td>
                                            <td>
                                                Next
                                            </td>
                                            <td>
                                                Poly Creap
                                            </td>
                                            <td>
                                                1231
                                            </td>
                                            <td>
                                                SW 202
                                            </td>
                                            <td>
                                                AR 22302
                                            </td>
                                            <td>
                                                1200 m
                                            </td>
                                            <td>
                                                17 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Beyond
                                            </td>
                                            <td>
                                                ASOS
                                            </td>
                                            <td>
                                                Lycra
                                            </td>
                                            <td>
                                                2322
                                            </td>
                                            <td>
                                                SW 203
                                            </td>
                                            <td>
                                                AR 22303
                                            </td>
                                            <td>
                                                400 m
                                            </td>
                                            <td>
                                                19 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Receiving to Washing</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li15" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px Arial;
                                    background: #e4ebf2;">
                                    Create Supplier Bills: <span style="color: #0000FF;">2 (1 Baweja, 1 Tex Fab)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="27%" style="background: #e4ebf2;">
                                                Supplier Name
                                            </td>
                                            <td width="15%" style="background: #e4ebf2;">
                                                SRV Date
                                            </td>
                                            <td width="17%" style="background: #e4ebf2;">
                                                SRV No.
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Claimed Qty.
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="14%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                28 Jan 12 (Sat)
                                            </td>
                                            <td>
                                                2302
                                            </td>
                                            <td>
                                                2000 m
                                            </td>
                                            <td>
                                                17 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Bills</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Tex Fab
                                            </td>
                                            <td>
                                                30 Jan 12 (Mon)
                                            </td>
                                            <td>
                                                2303
                                            </td>
                                            <td>
                                                2500 m
                                            </td>
                                            <td>
                                                19 Mar 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Bills</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li16" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px Arial;
                                    background: #e4ebf2;">
                                    Approval of Supplier Bills by Fabric Department: <span style="color: #0000FF;">2 (1
                                        Baweja, 1 Tex Fab)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="30%" style="background: #e4ebf2;">
                                                Supplier Group
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Bill Value (Rs.)
                                            </td>
                                            <td width="20%" style="background: #e4ebf2;">
                                                Supplier Bill No./Date
                                            </td>
                                            <td width="11%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="21%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                1,50,000
                                            </td>
                                            <td>
                                                6331
                                            </td>
                                            <td>
                                                30 Mar 12 (Fri)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Bills by Fab. Dept.</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Tex Fab
                                            </td>
                                            <td>
                                                1,80,000
                                            </td>
                                            <td>
                                                6332
                                            </td>
                                            <td>
                                                31 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Bills by Fab. Dept.</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li17" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Receipt of Supplier Bills by Finance Department: <span style="color: #0000FF;">2 (1
                                        Baweja, 1 Tex Fab)</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="30%" style="background: #e4ebf2;">
                                                Supplier Group
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Bill Value (Rs.)
                                            </td>
                                            <td width="19%" style="background: #e4ebf2;">
                                                Supplier Bill No./Date
                                            </td>
                                            <td width="12%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="21%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                1,50,000
                                            </td>
                                            <td>
                                                6331
                                            </td>
                                            <td>
                                                30 Mar 12 (Fri)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Bills by Finance Dept.</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Tex Fab
                                            </td>
                                            <td>
                                                1,80,000
                                            </td>
                                            <td>
                                                6332
                                            </td>
                                            <td>
                                                31 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Bills by Finance Dept.</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li18" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Supplier Outstanding payment: <span style="color: #0000FF;">BIPL Amount Due Current
                                        Fortnight: 1,30,000, Fabric: 70,000, Accessory: 30,000, Others: 30,000</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="26%" style="background: #e4ebf2;">
                                                Supplier Group
                                            </td>
                                            <td width="10%" style="background: #e4ebf2;">
                                                Delayed
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Total Due
                                            </td>
                                            <td width="17%" style="background: #e4ebf2;">
                                                Supplier Exposure
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="21%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                1,20,000
                                            </td>
                                            <td>
                                                1,30,000
                                            </td>
                                            <td>
                                                1,38,000
                                            </td>
                                            <td>
                                                31 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Outstanding paymnet</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Tex Fab
                                            </td>
                                            <td>
                                                2,20,000
                                            </td>
                                            <td>
                                                2,30,000
                                            </td>
                                            <td>
                                                2,38,000
                                            </td>
                                            <td>
                                                02 Apr 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Supplier Outstanding paymnet</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; display: None;" id="div_li19" class="cdiv">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" bordercolor="#F0F0F0"
                            rules="all" class="dashboard-holiday-app-tbl">
                            <tr>
                                <th style="text-align: left; color: #3a3a3b; padding: 0.5em; font: normal 11px/14px
Arial; background: #e4ebf2;">
                                    Supplier Payment by Finance Department: <span style="color: #0000FF;">Bawja: 1,30,000,
                                        Tex Fab: 70,000</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table width="99%" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#F0F0F0"
                                        rules="all" class="dashboard-holiday-app-tbl">
                                        <tr>
                                            <td width="30%" style="background: #e4ebf2;">
                                                Supplier Group
                                            </td>
                                            <td width="18%" style="background: #e4ebf2;">
                                                Amount to Pay
                                            </td>
                                            <td width="16%" style="background: #e4ebf2;">
                                                Authorized Payment
                                            </td>
                                            <td width="13%" style="background: #e4ebf2;">
                                                Target
                                            </td>
                                            <td width="23%" style="background: #e4ebf2;">
                                                Action
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Baweja
                                            </td>
                                            <td>
                                                1,30,000
                                            </td>
                                            <td>
                                                1,20,000
                                            </td>
                                            <td>
                                                31 Mar 12 (Sat)
                                            </td>
                                            <td>
                                                <a href="#">Supplier paymnet by Finance Dept.</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25">
                                                Tex Fab
                                            </td>
                                            <td>
                                                2,40,000
                                            </td>
                                            <td>
                                                2,10,000
                                            </td>
                                            <td>
                                                02 Apr 12 (Mon)
                                            </td>
                                            <td>
                                                <a href="#">Supplier paymnet by Finance Dept.</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
      
        </tr>
    </table>
     
</asp:Content>
