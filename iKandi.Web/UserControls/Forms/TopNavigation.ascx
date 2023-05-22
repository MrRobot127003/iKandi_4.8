<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavigation.ascx.cs"
    EnableViewState="true" Inherits="iKandi.Web.TopNavigation" %>
<%@ Register Src="SopFileUpload.ascx" TagName="SopFileUpload" TagPrefix="uc1" %>
<%--<%@ Register Src="CostingAndEnquiries.ascx" TagName="CostingAndEnquiries" TagPrefix="uc" %>--%>
<link href="../../css/colorbox.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">


    $(function () {
        $(".menu-tab", "#secure_greyline").hoverIntent(function () {

            if ($(this).find(".menu_dropdown").find("a").length == 0)
                return;

            $(this).find(".menu-box").each(function () {
                if ($(this).find("a").length == 0)
                    $(this).hide();
            });

            $(this).find(".menu_dropdown").slideDown();
            $(this).find(".menu_dropdown").css('height', 'auto');

            var height = $(this).find(".menu_dropdown").height();

            $(this).find(".menu_dropdown").find(".menu-box").height(height);

            var width = $(this).find(".menu_dropdown").width();
            var left = $(this).find(".menu_dropdown").position().left;

            if ((width + left) > document.body.clientWidth)
                $(this).find(".menu_dropdown").css({ left: $(this).find(".menu_dropdown").position().left - 25 - ((width + left) - document.body.clientWidth)
                });

        }, function () {
            $(this).find(".menu_dropdown").slideUp();
        });

        /* $(".menu-box").hover(function(){
        $(this).css({'background-color':'#ffffff'});
        }, function(){
        $(this).css({'background-color':'#f4f4f4'});
        });  
        */

        //debugger;
        // $("#secure_greyline").width($("#secure_banner_cor").width() + 40);
    });
    
</script>
<script type="text/javascript">

    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
    var proxy = new ServiceProxy(serviceUrl);

    var leadTime;
    var expectedDate;
    var deliveryDate;


    $(function () {
        leadTime = $('input.lead-time', '#main_content');
        expectedDate = $('input.expected-booking-date', '#main_content');
        deliveryDate = $('input.calculated-delivery-date', '#main_content');

        leadTime.keyup(function (e) {
            CalculateDeliveryDate();
        });

        expectedDate.change(function (e) {
            expectedDate.val($(this).val());
            CalculateDeliveryDate();
        });

        deliveryDate.change(function (e) {
            CalculateLeadTime($(this));
        });

        leadTime.keyup();
    });

    function CalculateDeliveryDate() {
        for (var i = 0; i < deliveryDate.length; i++) {
            var dd = new Date(ParseDateToSimpleDate(expectedDate[i].value));
            dd = dd.add(leadTime[i].value * 7).days();
            deliveryDate[i].value = ParseDateToDateWithDay(dd);
        }
    }

    function CalculateLeadTime(sender) {
        var txtLeadTime = sender.parents('div.booking_calculator tr').find('.lead-time');
        var txtExpectedDate = sender.parents('div.booking_calculator tr').find('.expected-booking-date');

        var expectedDate = new Date(ParseDateToSimpleDate(txtExpectedDate.val()));
        var deliveryDate = new Date(ParseDateToSimpleDate(sender.val()));

        if (deliveryDate < expectedDate) {
            sender.val(txtExpectedDate.val());
            txtLeadTime.val(0);
            return;
        }

        var leadTime = Math.round((deliveryDate - expectedDate) / (1000 * 60 * 60 * 24 * 7));
        txtLeadTime.val(leadTime);
    }

</script>
<script type="text/javascript">
    $(document).ready(function (e) {
        $("#notificationLink").click(function (e) {
            $("#notificationContainer").fadeToggle(300);
            //  $("#notification_count").hide();
            $("#notificationContainer1").hide();
            $("#notificationContainer2").hide();
            return false;

        });

        $("#notificationLink1").click(function (e) {
            $("#notificationContainer1").fadeToggle(300);
            //("#notification_count1").fadeOut("slow");
            $("#notificationContainer").hide();

            $("#notificationContainer2").hide();
            $("#notificationContainer3").hide();
            $("#Div4").show();
            return false;

        });

        $("#notificationLink2").click(function (e) {
            $("#notificationContainer2").fadeToggle(300);
            // $("#notification_count2").fadeOut("slow");
            $("#notificationContainer").hide();
            $("#notificationContainer1").hide();
            $("#notificationContainer3").hide();
            return false;

        });

        $("#notificationLink3").click(function (e) {
            $("#notificationContainer3").fadeToggle(300);
            $("#notification_count3").fadeOut("slow");
            $("#notificationContainer").hide();
            $("#notificationContainer1").hide();
            $("#notificationContainer2").hide();
            return false;

        });

        $("#notificationLink4").click(function (e) {
            $("#notificationContainer4").fadeToggle(300);

            $("#notificationContainer").hide();
            $("#notificationContainer1").hide();
            $("#notificationContainer2").hide();
            $("#notificationContainer3").hide();
            return false;

        });


        //          $("body").click(function () { // binding onclick to body

        //              $("#notificationContainer #CentralDiv #mytask").slideUp(100); // hiding popups

        //              $("#notificationContainer").hide();
        //            
        //          });

        //Document Click
        $(document).click(function () {

            //$("#notificationContainer").hide();


        });
        $("#notificationClose").click(function () {
            $("#notificationContainer").hide();
        });


        $("#Button1").click(function () {
            $("#notificationContainer1").hide();
        });


        $("#Button2").click(function () {

            $("#notificationContainer3").hide();
        });
        $("#Button3").click(function () {

            $("#notificationContainer4").hide();
        });
        //Popup Click
        $("#notificationContainer").click(function () {

        });

        $("#notificationContainer1").click(function () {

        });

        $("#notificationContainer2").click(function () {

        });

    });
    $(document).click(function () {
        // $("#notificationContainer").hide();
        // $("#notificationContainer1").hide();
        $("#notificationContainer2").hide();
        //$("#notificationContainer3").hide();
    });



    //   $(document).mouseup(function (e) {

    //        var popup = $("#notificationContainer");
    //        if (!$('#notificationLink').is(e.target) && !popup.is(e.target) && popup.has(e.target).length == 0) {
    //            popup.hide(500);
    //        }


    //        var popup1 = $("#notificationContainer1");
    //        if (!$('#notificationLink1').is(e.target) && !popup.is(e.target) && popup.has(e.target).length == 0) {
    //            popup.hide(500);
    //        }
    //        var popup2 = $("#notificationContainer2");
    //        if (!$('#notificationLink2').is(e.target) && !popup.is(e.target) && popup.has(e.target).length == 0) {
    //            popup.hide(500);
    //        }

    //        var popup3 = $("#notificationContainer3");
    //        if (!$('#notificationLink3').is(e.target) && !popup.is(e.target) && popup.has(e.target).length == 0) {
    //            popup.hide(500);
    //        }
    //    });

</script>
<script type="text/javascript">

    $(document).ready(function () {
        //Examples of how to assign the Colorbox event to elements

        $(".inline").colorbox({ inline: true, width: "300px", innerHeight: 100 });
        $(".youtube").colorbox({ iframe: true, innerWidth: 640, innerHeight: 309 });
        $(".iframe").colorbox({ iframe: true, innerWidth: 640, innerHeight: 390 });
        $(".youtube1").colorbox({ iframe: true, innerWidth: 640, innerHeight: 309 });

        $('#ctl00_TopNavigation_rblradbutton input').change(function () {
            $('#ctl00_TopNavigation_hdnRadioButton').val((this).value);
        });

    });
</script>
<script type="text/javascript">
    var SelectedVal;
    $(function () {

        $("input[type=text].costing-style").autocomplete("/Webservices/iKandiService.asmx/SuggestStyles", { dataType: "xml", datakey: "string", max: 100, "width": "130px" });

        $("input[type=text].costing-style", "#main_content").result(function () {

            var p = $(this).val().split('-');
            $(this).val(p[0]);

        });

    });

    function launchCosting() {
        //debugger;
        //alert(srcElem);
        //  var txtStyleNumber = $('input[type=text].costing-style');
        var txtStyleNumber = $('#ctl00_TopNavigation_txtStyleNumberSearch').val();

        var SingleVersion = $('#ctl00_TopNavigation_hdnRadioButton').val();


        //var srcElem = $("#aCosting");
        //alert(srcElem);
        //        if (txtStyleNumber.length < 8) {
        //            return;
        //        }
        //        alert($.trim(txtStyleNumber));
        //        var sn = $.trim(txtStyleNumber);
        var style = '';
        proxy.invoke("GetStyleNumber_From_Order", { sn: $.trim(txtStyleNumber) },
                                                            function (result) {
                                                                style = result[0].StyleNumber;
                                                                var url = "/Internal/Sales/CostingSheetNew.aspx?sn=" + style + "&SingleVersion=" + SingleVersion;
                                                                window.open(url, '_blank');
                                                                //  $(".btnclick").attr("href", "/Internal/Sales/CostingSheet.aspx?sn=" + style);

                                                            },
                                             onPageError, false, false);


        // if (sn.split(' ').length == 3)
        //     sn = $.trim(sn.substring(0, sn.lastIndexOf(' ')));

    }

    function launchMO(srcElem) {
        var txtStyleNumber = $('#ctl00_TopNavigation_txtStyleNumberSearch').val();
        //    if (txtStyleNumber.length < 8) {
        //      return;
        //    }
        var sn = $.trim(txtStyleNumber);

        $(srcElem).attr("href", "/Internal/OrderProcessing/frmMO.aspx?SerialNumber=" + sn);
    }

    function onPageError(error) {
        alert(error.Message + ' -- ' + error.detail);
    }

</script>
<style type="text/css">
    .subheading
    {
        background-color: #f2f2f2;
        color: #000000;
        cursor: pointer;
        font: bold 12px Arial;
        padding: 5px 5px 5px 10px;
    }
    .subheading img
    {
        display: none;
    }
    .mytask_submenu2
    {
        background-color: #ffffff;
        color: #000000;
        cursor: pointer;
        font: 12px Arial;
    }
    
    .mytask_submenu21
    {
        background-color: #FFFFFF;
        font: normal 12px Arial;
        color: #000000;
        cursor: pointer;
    }
    .design2
    {
        color: #0066ff !important;
        font: 12px/20px Arial;
        margin-top: 1px;
        padding-left: 10px;
        text-align: left;
        width: 97%;
        text-transform: capitalize;
    }
    
    #tooltipdb1
    {
        z-index: 10000000;
    }
    .loadingimage
    {
        z-index: 10000000000;
    }
    #colorbox
    {
        box-shadow: 1px 2px 3px #ccc;
        background: #fff;
    }
    .right-menu
    {
        float: right;
        width: 34%;
    }
    .right-menu img
    {
        width: 20px;
        border: 0px;
    }
    
    DIV#secure_greyline UL LI A
    {
        color: gray;
        display: block; /*float: left;*/
        font-family: Helvetica;
        font-size: 13px;
        font-weight: bold;
        padding: 0px 5px 0px;
        vertical-align: middle;
        border-right: 1px solid #f5f5f5;
        text-decoration: none;
    }
    
    DIV#secure_greyline UL LI A:hover
    {
        background: #153885;
        color: #fff;
        height: 24px;
        padding: 0px 5px 0;
    }
    .design2 a
    {
        text-decoration: none;
        text-transform: capitalize;
    }
    
    .notification_li1 img
    {
        border: none;
    }
    .home a:hover
    {
        background: #fff !important;
    }
    .home img
    {
        border: 0px;
    }
    .AllMyTask .design2
    {
        border-bottom: 1px solid #ccc;
    }
    .menu_heading
    {
        text-transform: capitalize;
    }
    div.menu_item a
    {
        text-transform: capitalize;
    }
    .noborder td
    {
        border: none !important;
    }
    .noborder td label
    {
        color: Black !important;
    }
    
    .ac_results
    {
        border-color: #c9c6c6 !important;

    }
    .da_submit_button
    {
        font-size: 12px;
        height: 22px;
        padding: 2px 9px;
        line-height: 13px;
    }
    .da_submit_button:hover
    {
        font-size: 12px;
        height: 22px;
        padding: 2px 9px;
        line-height: 13px;
    }
    #cboxContent
    {
        height: 115px !important;
    }
    #colorbox
    {
        height: 150px !important;
    }
    #cboxClose
    {
        height: 15px !important;
    }
    @media (min-width: 1601px) and (max-width: 1920px)
    {
    
        .CarretAdd:after
        {
            content: "";
            position: absolute;
            top: -2%;
            left: 84.5%;
            border-width: 20px;
            border-style: solid;
            border-color: transparent transparent #a9a5a5 transparent;
        }
    }
    @media (min-width: 1367px) and (max-width: 1600px)
    {
        .CarretAdd
        {
            left: 290px !important;
        }
        .CarretAdd:after
        {
            content: "";
            position: absolute;
            top: -2%;
            left: 96.5%;
            border-width: 20px;
            border-style: solid;
            border-color: transparent transparent #a9a5a5 transparent;
        }
    }
    @media (min-width: 1281px) and (max-width: 1366px)
    {
        .CarretAdd
        {
            left: 340px !important;
        }
        .CarretAdd:after
        {
            content: "";
            position: absolute;
            top: -2%;
            left: 95.5%;
            border-width: 20px;
            border-style: solid;
            border-color: transparent transparent #a9a5a5 transparent;
        }
    
    }
    #ctl00_TopNavigation_hypLegacy img
    {
        width: 90%;
    }
    .header-textBack
    {
        background: #39589c;
        color: #f5f5f5;
        font-size: 12px;
        font-family: Arial;
        padding: 5px 0px 2px 7px;
    }
    td.notification-text
    {
        border: 1px solid #ccc !important;
    }
    .notification-table
    {
        border: 1px solid #999 !important;
    }
    #notificationsBody1 #Div4
    {
        overflow: auto !important;
    }
    #notificationsBody3 #Div8
    {
        overflow: auto !important;
    }
    
    
    
    
    .showtooltip
    {
        position: relative;
        display: inline-block;
    }
    
    .showtooltip .tooltiptext
    {
        display: none;
        width: 220px;
        background-color: #ebfbff;
        color: #615f5f;
        text-align: left;
        border-radius: 6px;
        padding: 5px 0px 5px 8px;
        position: absolute;
        z-index: 1;
        top: 20px;
        left: 50%;
        margin-left: -60px;
        opacity: 0;
        transition: opacity 0.3s;
        font-size: 10px;
        line-height: 14px;
    }
    
    .showtooltip .tooltiptext::after
    {
        content: "";
        position: absolute;
        top: -10px;
        left: 20px;
        margin-left: -5px;
        border-width: 5px;
        border-style: solid;
        border-color: transparent transparent #ebfbff transparent;
    }
    
    .showtooltip:hover .tooltiptext
    {
        display: block;
        opacity: 1;
    }
</style>
<script type="text/javascript">
    function BiplMeeting() {
        // debugger;
        sURL = "../../BiplMeeting.aspx";
        Shadowbox.init({ animate: true, animateFade: true, modal: true });
        Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 1000, width: 1800, modal: true, animate: true, animateFade: true });
        $('#sb-wrapper').addClass('CarretAdd');
        return false;
    }

    function MainWebsite_url() {
        //  debugger;
        var MainUrlPath = window.location.origin;
        document.getElementById("AddMainUrl").href = MainUrlPath + ":84/public/login.aspx";

    }
</script>
<div id="secure_greyline" style="margin-top: 5px; margin-bottom: 5px;">
    <div style="float: left; width: 65%;">
        <ul>
            <li class="home"><a href="/internal/Dashboard_Task.aspx">
                <img class="hmlogo" />
            </a></li>
            <asp:HiddenField ID="hidval" runat="server" />
            <asp:Repeater ID="repeaterPhase" runat="server" OnItemDataBound="repeaterPhaseItemDataBound">
                <ItemTemplate>
                    <li id="tab_setup" class="menu-tab"><a href="#" style="text-transform: none; font-weight: normal;">
                        <%# Eval("Name")%></a>
                        <div id="menu_setup1" class="hide_me menu_dropdown menu-box1">
                            <asp:Repeater ID="repeaterSubPhase" runat="server" OnItemDataBound="repeaterSubPhaseItemDataBound">
                                <ItemTemplate>
                                    <div style="float: left; width: 170px;" class="menu-box equal-column">
                                        <div class="menu_title">
                                            <%# Eval("Name") %>
                                        </div>
                                        <div class="menu_heading" style="color: #E91677">
                                            Forms
                                        </div>
                                        <asp:Repeater ID="repeaterTypeForms" runat="server" OnItemDataBound="repeaterLinkItemDataBound">
                                            <ItemTemplate>
                                                <div class="menu_item">
                                                    <asp:HyperLink ID="lnkMenuItem" runat="server" Text='<%# Eval("ApplicationModuleName")%>'
                                                        NavigateUrl='<%# Eval("Path").ToString() %>'><%# Eval("ApplicationModuleName")%> </asp:HyperLink>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div class="menu_heading" style="color: #E91677">
                                            Files
                                        </div>
                                        <asp:Repeater ID="repeaterTypeFiles" runat="server" OnItemDataBound="repeaterLinkItemDataBound">
                                            <ItemTemplate>
                                                <div class="menu_item">
                                                    <asp:HyperLink ID="lnkMenuItem" runat="server" NavigateUrl='<%# Eval("Path").ToString() %>'><%# Eval("ApplicationModuleName")%> </asp:HyperLink>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div class="menu_heading" style="color: #E91677" runat="server" id="DivAdmin">
                                            Admin
                                        </div>
                                        <asp:Repeater ID="repeateradmin" OnItemDataBound="repeateradminLinkItemDataBound"
                                            runat="server">
                                            <ItemTemplate>
                                                <div class="menu_item">
                                                    
                                                    <asp:HyperLink ID="lnkMenuItem" Text='<%# Eval("ApplicationModuleName")%>' runat="server"
                                                        NavigateUrl='<%# Eval("Path").ToString()%>'><%# Eval("ApplicationModuleName")%>  </asp:HyperLink>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--
                                    <div class="menu_heading" style="color:#E91677">
                                        Reports
                                    </div>
                                   <asp:Repeater ID="repeaterTypeReports" runat="server" OnItemDataBound="repeaterLinkItemDataBound">
                                        <ItemTemplate>
                                            <div class="menu_item">
                                                <asp:HyperLink ID="lnkMenuItem" runat="server" NavigateUrl='<%# Eval("Path").ToString() %>'><%# Eval("ApplicationModuleName")%>  </asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>--%>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div style="clear: both">
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <div style="clear: both;">
            </div>
        </ul>
    </div>
    <div class="right-menu">
        <div style="float: right; width: 110px; margin-top: 7px;">
            <div id="divmeeting" onclick="BiplMeeting()" class="notifications" style="float: left;
                width: 44px;">
                <img src="../../images/Meetings.png" style="width: 40px; cursor: pointer" />
            </div>
            <div style="float: left; margin-top: -4px;" title="Go to Legacy Website" onclick="MainWebsite_url()">
                <a id="AddMainUrl" target="_blank">
                    <img src="../../images/LegacyImage.png" style='width: 85%;' />
                </a>
            </div>
            <a href='<%= (Request.IsAuthenticated) ? ResolveUrl("~/internal/Logout.aspx") : ResolveUrl("~/public/login.aspx") %>'
                class="topmenu2border" style="text-transform: capitalize !important;">
                <%= (Request.IsAuthenticated) ? "" : "" %>
                <img src="../../Uploads/Photo/logout.png" title="Log Out" alt="Log Out" /></a>
        </div>
        <div style="float: right; width: auto; margin: 7px 5px 0px;">
            <a href="../../Internal/OrderProcessing/frmMO.aspx" target="_blank">
                <asp:Image ID="ImgMo" runat="server" ToolTip="Manage Order" Visible="false" ImageUrl="~/Uploads/Photo/manage-order.jpg" /></a>
            <a href="../../Internal/Sales/OrderPlace.aspx" target="_blank">
                <asp:Image ID="imgorder" runat="server" Visible="false" ToolTip="Order Form" ImageUrl="~/Uploads/Photo/order-form.jpg" /></a>
            <asp:Repeater ID="repGlobal" runat="server" OnItemDataBound="repGlobalItemDataBound"
                Visible="false">
                <ItemTemplate>
                    <div style="float: left; width: 35px">
                        <a href="../../Internal/OrderProcessing/frmMO.aspx" target="_blank">
                            <asp:Image ID="img" runat="server" AlternateText='<%# Eval("imagepath")%>' />
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <a class='inline' href="#inline_content">
                <asp:Image ID="imgcost" ToolTip="Costing" ImageUrl="~/Uploads/Photo/costings.png"
                    Visible="false" runat="server" /></a> <a href="../../Internal/OrderProcessing/MoBudget.aspx"
                        target="_blank">
                        <asp:Image ID="imgMoBudget" runat="server" ToolTip="Budget" Visible="false" ImageUrl="~/Uploads/Photo/budget.jpg" /></a>
            <a class='iframe' href="../../Internal/Users/LatestStyle.aspx">
                <asp:Image ID="imglatestStyle" ToolTip="Latest Style" Visible="false" runat="server"
                    ImageUrl="~/Uploads/Photo/updated-style.jpg" /></a> <a class='youtube' href="../../Internal/Users/BookingCalucaltor.aspx">
                        <asp:Image ID="imgCalCulator" ToolTip="Booking Calucaltor" Visible="false" runat="server"
                            ImageUrl="~/Uploads/Photo/calculator.jpg" /></a> <a class='youtube1' href="../../Internal/Users/HolyDaysEvent.aspx">
                                <asp:Image ID="Image2" ToolTip="Upcoming Holidays / Events" Visible="true" runat="server"
                                    ImageUrl="~/Uploads/Photo/holiday-icon.png" /></a>
        </div>
        <div style="float: right; width: 30px; position: relative;">
            <div class="notification_li">
                <span id="notification_count1" runat="server" class="notification_count1">
                    <asp:Label ID="lblcount" runat="server"></asp:Label></span> <a href="#" id="notificationLink"
                        title="Task">
                        <img src="../../Uploads/Photo/dashboard.png" />
                    </a>
                <div id="notificationContainer">
                    <div id="notificationsBody" class="notifications">
                        <div class="panelcontent2">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="padding: 0px 0px 5px !important; border: 0px;">
                                        <div id="mytask" class="subheading" style="text-transform: none; background: #39589c;
                                            color: #f5f5f5">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="text-align: left; color: #f5f5f5; font-size: 12px;">
                                                        My Tasks &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <%--<asp:Image ID="Image2" style="width:4%;" CssClass="mytaskloadingimage"  ImageUrl="~/App_Themes/ikandi/images1/loading29.gif" runat="server" />--%>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td style="text-align: right; color: #f5f5f5; font-size: 12px;">
                                                        (<asp:Label ID="ltMyTask" runat="server" Text="0" CssClass="MyTaskCount"></asp:Label>)
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="mytask_submenu" class="AllMyTask mytask_submenu2">
                                            <asp:Repeater ID="rptMyTask" runat="server">
                                                <ItemTemplate>
                                                    <div class="design2" id="task" onclick="JavaScript:GetMyTask(<%#Eval("TaskId") %>,this)">
                                                        <div style="float: left" align="left">
                                                            <a id="alittask" runat="server" title='<%#Eval("Description") %>'>
                                                                <%#Eval("Task_Name") %></a>
                                                            <%--<asp:Literal ID="litTask" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>--%>
                                                        </div>
                                                        <div style="float: right; padding-right: 5px;" align="right">
                                                            (<asp:Literal ID="Literal1" runat="server" Text='<%#Eval("Task_Count") %>'></asp:Literal>)
                                                        </div>
                                                        &nbsp;
                                                    </div>
                                                    <div id="CentralDiv">
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div id="teamtask" class="subheading" style="text-transform: none;" onclick="JavaScript:LoadTeamTask();">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="text-align: left;">
                                                        Team Tasks &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Image ID="Image1" Style="bottom: 10%;" CssClass="teamtaskloadingimage" ImageUrl="~/App_Themes/ikandi/images1/loading128.gif"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td style="text-align: right;">
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
                    <div id="notificationFooter">
                        <button type="button" id="notificationClose" style="float: right;">
                            x</button>
                        <div style="clear: both;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="ntfication" runat="server" visible="false" style="float: right; width: 30px;
            position: relative;">
            <div class="notification_li1">
                <span id="notification_count1" class="notification_count1">
                    <asp:Label ID="Lblnotificationcount" runat="server" Text="0"></asp:Label></span>
                <a href="javascrip:void(0);" id="notificationLink1" class="notificationLink1" title="Events">
                    <img src="../../Uploads/Photo/Events.png" />
                </a>
                <div id="notificationContainer1" class="notificationContainer2">
                    <div id="notificationsBody1" class="notifications">
                        <asp:GridView ID="grdNotiFication" runat="server" Visible="false" AutoGenerateColumns="false"
                            ForeColor="Black" BorderWidth="0" OnRowDataBound="grdNotiFication_RowDataBound"
                            class="notification-table" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Events">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmsg" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                        <div style="text-align: right; font-weight: bold; font-size: 9px; color: Gray;">
                                            <asp:Label ID="lblhour" runat="server" Text='<%#Eval("Days") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="header-textBack" />
                                    <ItemStyle CssClass="notification-text" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%-- new task for notification --%>
                        <div id="Div1">
                            <div id="DivnewNotificaton" class="notifications">
                                <div class="panelcontent2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="padding: 0px 0px 5px !important; border: 0px;">
                                                <div id="Div3" class="subheading" style="text-transform: none; background: #39589c;
                                                    color: #f5f5f5">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td style="color: #f5f5f5; font-size: 12px;">
                                                                My Events &nbsp;&nbsp;&nbsp;&nbsp;
                                                                <%--<asp:Image ID="Image2" style="width:4%;" CssClass="mytaskloadingimage"  ImageUrl="~/App_Themes/ikandi/images1/loading29.gif" runat="server" />--%>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="right" style="color: #f5f5f5; font-size: 12px;">
                                                                (<asp:Label ID="lblnotificatonctiontask" runat="server" Text="0" CssClass="MyTaskCount"></asp:Label>)
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div id="Div4" class="AllMyTask mytask_submenu21">
                                                    <asp:Repeater ID="repnotifaciton" runat="server">
                                                        <ItemTemplate>
                                                            <div class="design2" id="task" onclick="JavaScript:GetMyTaskNotificaton(<%#Eval("EmailId") %>,this)">
                                                                <div style="float: left" align="left">
                                                                    <%--  <a id="alittask" runat="server" title='<%#Eval("Description") %>'>--%>
                                                                    <%#Eval("Name")%></a>
                                                                    <%--<asp:Literal ID="litTask" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>--%>
                                                                </div>
                                                                <div style="float: right; padding-right: 5px;" align="right">
                                                                    (<asp:Literal ID="Literal1" runat="server" Text='<%#Eval("cnt") %>'></asp:Literal>)
                                                                </div>
                                                                &nbsp;
                                                            </div>
                                                            <div id="CentralDiv1">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="Div7">
                                <button type="button" id="Button1" style="float: right;">
                                    x</button>
                                <div style="clear: both;">
                                </div>
                            </div>
                        </div>
                        <%-- END new task for notification --%>
                    </div>
                </div>
            </div>
        </div>
        <%--soap--%>
        <%--end--%>
        <%--   Task Notifcatiin --%>
        <div id="Divtasknotifaction" runat="server" visible="False" style="float: right;
            width: 30px; position: relative;">
            <div class="notification_li1">
                <span id="notification_count3" class="notification_count1">
                    <asp:Label ID="Label3" runat="server" Text="0"></asp:Label></span> <a href="#" id="notificationLink3"
                        title="Task Completion" class="notificationLink1">
                        <img src="../../Uploads/Photo/task-notification.png" />
                    </a>
                <div id="notificationContainer3" class="notificationContainer1">
                    <div id="notificationsBody3" class="notifications">
                        <%-- <asp:GridView ID="Grdnotificatontask" runat="server" AutoGenerateColumns="false"
              ForeColor="Black" BorderWidth="0" OnRowDataBound="Grdnotificatontask_RowDataBound"
              class="notification-table" Width="100%">
              <Columns>
                <asp:TemplateField HeaderText=" Task Completion">
                  <ItemTemplate>
                    <div style="width: 100%;">
                    <table width="100%" cellpadding="0" cellspacing="0"> 
                    <tr>
                    <td>
                     <div style="float: left; width: 45px;">
                        <asp:Image ID="img" runat="server" Width="40px" Height="40px" />
                      </div>
                    </td>
                    <td valign="top">
                     <div style="width: auto; vertical-align: middle;">
                        <a style="text-transform:none; color:#000000; text-decoration:none;" href='<%# Eval("OrderDetailId", "../../Internal/OrderProcessing/ManageOrders.aspx?TaskCompleteOrderDetailId={0}") %>' target="_blank"><asp:Label ID="lblmsg" runat="server"></asp:Label></a>
                        <asp:HiddenField ID="status_modename" runat="server" Value='<%#Eval("status_modename") %>' />
                        <asp:HiddenField ID="StatusModeID" runat="server" Value='<%#Eval("StatusModeID") %>' />
                        <asp:HiddenField ID="StyleNumber" runat="server" Value='<%#Eval("StyleNumber") %>' />
                        <asp:HiddenField ID="SerialNumber" runat="server" Value='<%#Eval("SerialNumber") %>' />
                        <asp:HiddenField ID="CompanyName" runat="server" Value='<%#Eval("CompanyName") %>' />
                        <asp:HiddenField ID="DepartmentName" runat="server" Value='<%#Eval("DepartmentName") %>' />
                        <asp:HiddenField ID="Quantity" runat="server" Value='<%#Eval("Quantity") %>' />
                        <asp:HiddenField ID="ContractNumber" runat="server" Value='<%#Eval("ContractNumber") %>' />
                        <asp:HiddenField ID="LineItemNumber" runat="server" Value='<%#Eval("LineItemNumber") %>' />
                        <asp:HiddenField ID="BIPLPrice" runat="server" Value='<%#Eval("BIPLPrice") %>' />
                        <asp:HiddenField ID="Url" runat="server" Value='<%#Eval("Url") %>' />
                          <asp:HiddenField ID="hdninr" runat="server" Value='<%#Eval("INR") %>' />
                      </div>
                           <div style="text-align: right; font-weight: bold; font-size: 9px; color: Gray; vertical-align:bottom;">
                        <asp:Label ID="lblhour" runat="server" Text='<%#Eval("DAYStask") %>'></asp:Label>
                      </div>
                    </td>
                    </tr>
                    
                    
                    </table>
                     
                     
                      <div style="clear: both;">
                      </div>
               
                  </ItemTemplate>
                  <HeaderStyle CssClass="header-text" />
                  <ItemStyle CssClass="notification-text" />
                </asp:TemplateField>
              </Columns>
            </asp:GridView>--%>
                        <%--
            new TaskCompletion--%>
                        <div id="Div2">
                            <div id="Div5" class="notifications">
                                <div class="panelcontent2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="padding: 0px 0px 5px !important; border: 0px;">
                                                <div id="Div6" class="subheading" style="text-transform: none; background: #39589c;
                                                    color: #f5f5f5">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td style="color: #f5f5f5; font-size: 12px;">
                                                                Task Completion &nbsp;&nbsp;&nbsp;&nbsp;
                                                                <%--<asp:Image ID="Image2" style="width:4%;" CssClass="mytaskloadingimage"  ImageUrl="~/App_Themes/ikandi/images1/loading29.gif" runat="server" />--%>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="right" style="color: #f5f5f5; font-size: 12px;">
                                                                (<asp:Label ID="Label4" runat="server" Text="0" CssClass="MyTaskCount"></asp:Label>)
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div id="Div8" class="AllMyTask mytask_submenu21">
                                                    <asp:Repeater ID="RepTaskCompeltion" runat="server">
                                                        <ItemTemplate>
                                                            <div class="design2" id="task" onclick="JavaScript:GetMyTaskComplete(<%#Eval("StatusModeID") %>,this)">
                                                                <div style="float: left" align="left">
                                                                    <%--  <a id="alittask" runat="server" title='<%#Eval("Description") %>'>--%>
                                                                    <%#Eval("Name")%></a>
                                                                    <%--<asp:Literal ID="litTask" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>--%>
                                                                </div>
                                                                <div style="float: right; padding-right: 5px;" align="right">
                                                                    (<asp:Literal ID="Literal1" runat="server" Text='<%#Eval("cnt") %>'></asp:Literal>)
                                                                </div>
                                                                &nbsp;
                                                            </div>
                                                            <div id="CentralDiv2">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="Div9">
                                <button type="button" id="Button2" style="float: right;">
                                    x</button>
                                <div style="clear: both;">
                                </div>
                            </div>
                        </div>
                        <%-- End Task Completion--%>
                    </div>
                </div>
            </div>
        </div>
        <%--   Task Notifcatiin --%>
        <div id="delay" runat="server" visible="false" style="float: right; width: 30px;
            position: relative;">
            <div class="notification_li2">
                <span id="notification_count2">
                    <asp:Label ID="Label2" runat="server" Text="0"></asp:Label></span> <a href="#" id="notificationLink2"
                        title="Delay">
                        <img src="../../Uploads/Photo/delay.png" />
                    </a>
                <div id="notificationContainer2">
                    <div id="notificationsBody2" class="notifications">
                        <asp:GridView ID="GrdDelay" runat="server" AutoGenerateColumns="false" ForeColor="Black"
                            BorderWidth="0" class="notification-table" Width="100%" OnRowCommand="GrdDelay_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Delay">
                                    <ItemTemplate>
                                        <div class="design2">
                                            <div style="float: left" align="left">
                                                <asp:LinkButton ID="ltdelay" runat="server" Visible="false" ValidationGroup="G1"
                                                    CommandArgument='<%#Eval("StatusModeID")%>' Text='<%#Eval("status_modename")%>'>
                        
                                                    
                                                </asp:LinkButton>
                                                <%--<asp:HyperLink ID="hyp" runat="server" Target="_blank" 
                          navigateurl='<%# /Internal/OrderProcessing/ManageOrders.aspx?DelayStatusId={0}",Eval("StatusModeID") %>' >tt </asp:HyperLink>--%>
                                                <a id="ltdealy" href='<%# Eval("StatusModeID", "../../Internal/OrderProcessing/frmMO.aspx?DelayStatusId={0}") %>'
                                                    target="_blank" runat="server">
                                                    <%#Eval("status_modename")%></a>
                                                <%--<asp:Literal ID="litTask" runat="server" Text='<%#Eval("Task_Name") %>'></asp:Literal>--%>
                                            </div>
                                            <div style="float: right; padding-right: 5px;" align="right">
                                                (<asp:Literal ID="lternal1" runat="server" Text='<%#Eval("Count") %>'></asp:Literal>)
                                            </div>
                                            &nbsp;
                                        </div>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="header-textBack" />
                                    <ItemStyle CssClass="notification-text" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div id="soap" runat="server" style="float: right; width: 30px; position: relative;"
            visible="false">
            <div class="notification_li2">
                <a href="#" id="notificationLink4" title="Standard Operating Procedure"> <img src="../../Uploads/Photo/sop.png" /></a>
                <div id="notificationContainer4">
                    <div id="notificationsBody4" class="notifications">
                        <uc1:SopFileUpload ID="SopFileUpload1" runat="server" />
                    </div>
                    <div id="Div10">
                        <button type="button" id="Button3" style="float: right;margin-top:5px;">
                            x</button>
                        <div style="clear: both;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: right; vertical-align: top; font-size: 11px; text-align: left;
            z-index: auto; width: 55px; padding-top: 9px;" align="left">
            <a href="/internal/Ikandi_aspx_headertooltip/index.html" target="_blank" style="text-decoration: none;">
                <asp:Label ID="Label1" Text="Ver 9.2.7" runat="server" Style="font-size: 11px; text-decoration: none;
                    color: #000000; text-transform: capitalize !important; text-align: left;"></asp:Label>
            </a>
        </div>
        <%--Coasting--%>
        <div style="display: none">
            <div id="inline_content">
                <div class="booking_calculator">
                    <table width="100%" style="border-collapse: collapse" cellspacing="0" border="0">
                        <tr>
                            <td style="width: 47%; font-size: 12px; text-transform: none; text-align: center;
                                color: #000; margin-bottom: 5px;">
                                <%--<div class="showtooltip">--%>
                                <%--Style/Sr/Ln/Cn No.--%>
                                <div>
                                    Identifier
                                    <%--<span class="tooltiptext">Please enter full value in case of <span style="color:#0f0f0f;"><br /> Line Number <br /> Contract Number <br /> Serial Number </span>  <br /> For Ex. Line No. - <span style="background-color:Yellow;">812824 c</span></span>                                --%>
                                </div>
                            </td>
                            <td colspan="2" class="blue_center_text" style="width: 60%; margin-bottom: 5px;">
                                <asp:TextBox runat="server" ID="txtStyleNumberSearch" CssClass="costing-style do-not-disable"
                                    title="Please Enter Style Number" Style="width: 80%; color: Black;"></asp:TextBox>
                            </td>
                            <%--<td width="25%">--%>
                            <%--<div>
                  <div style="float: left; padding: 2px">
                    <a style="" target="_blank" class="validate-form do-not-disable costing-style-go"
                      onclick="launchCosting( this)">
                      <div class="go_small">
                      </div>
                    </a>
                  </div>
                  <div style="float: left; padding: 2px">
                    <asp:Button ID="btnEnquiry" runat="server" Visible="false" CssClass="enquiry_small" />
                  </div>
                </div>--%>
                            <%--</td>--%>
                        </tr>
                        <tr style="line-height: 5px">
                            <td style="border: 0px !important;">
                                &nbsp;
                            </td>
                            <td style="border: 0px !important;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 0px !important;" colspan="2">
                                <asp:RadioButtonList ID="rblradbutton" runat="server" RepeatDirection="Horizontal"
                                    CssClass="noborder" Width="100%">
                                    <asp:ListItem Selected="True" Value="0">All View</asp:ListItem>
                                    <asp:ListItem Value="1">Single View</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:HiddenField ID="hdnRadioButton" runat="server" />
                            </td>
                        </tr>
                        <tr style="line-height: 10px">
                            <td style="border: 0px !important;">
                                &nbsp;
                            </td>
                            <td style="border: 0px !important;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 35%; text-align: center; border: 0px !important">
                                <%--<div align="center">
                  <div style="float: left; padding: 2px">--%>
                                <%--   <asp:Button ID="btnCsting" Text="Costing" CssClass="da_submit_button btnclick" runat="server" />--%>
                                <a id="aCosting" target="_blank" class="da_submit_button" onclick="launchCosting()">
                                    <%--<div class="go_small"></div>--%>
                                    Costing </a>
                                <%--</div>
                  <div style="float: left; padding: 2px">
                    <asp:Button ID="btnEnquiry" runat="server" Visible="false" CssClass="enquiry_small" />
                  </div>
                </div>--%>
                            </td>
                            <td align="right" style="width: 55%; text-align: center; border: 0px !important;">
                                <a style="" target="_blank" class="validate-form do-not-disable costing-style-go da_submit_button costing-butt"
                                    onclick="launchMO( this)">
                                    <%--  <div class="go_small"></div>--%>
                                    Manage Order </a>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--  <uc:CostingAndEnquiries ID="CostingAndEnquiries1" runat="server" />--%>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>
<script type="text/javascript" src="../../js/jquery.colorbox.js"></script>
<script src="../../js/colorpicker.js" type="text/javascript"></script>
