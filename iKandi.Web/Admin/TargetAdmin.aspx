<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TargetAdmin.aspx.cs" Inherits="iKandi.Web.Admin.TargetAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript">
        var PreFromStatusId;
        function GetPreviousValue(DropDownList) {
            PreFromStatusId = DropDownList.options[DropDownList.selectedIndex].value;
        }

        function SaveFromStatus(DropDownList) {
            var row;
            var rowIndex;
            var StatusId;

            if (DropDownList.id == "gvTargetAdmin_ctl02_ddlFromStatus_freezeitem") {
                StatusId = 1;
            }
            else {
                row = DropDownList.parentNode.parentNode;
                rowIndex = row.rowIndex - 1;
                StatusId = row.cells[1].getElementsByTagName("input")[0].value;
            }

            var PreviousFromStatusId = PreFromStatusId;
            var FromStatusId = DropDownList.options[DropDownList.selectedIndex].value;

            //      if (FromStatusId == 0) {
            //        alert("Please select a From Status.");
            //        var DropDownListId = DropDownList.id;
            //        document.getElementById(DropDownListId).value = PreviousFromStatusId;
            //        return false;
            //      }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateFromStatus",
                data: "{ StatusId:'" + StatusId + "', FromStatusId:'" + FromStatusId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateIsRelevantToNewsLetter(checkbox) {
            var row;
            var rowIndex;
            var StatusId;

            if (checkbox.id == "gvTargetAdmin_ctl02_chkNewsLetter_freezeitem") {
                StatusId = 1;
            }
            else {
                row = checkbox.parentNode.parentNode;
                rowIndex = row.rowIndex - 1;
                StatusId = row.cells[1].getElementsByTagName("input")[0].value;
            }

            var IsRelevantToNewsLetter = false;
            if (checkbox.checked) {
                IsRelevantToNewsLetter = true;
            }
            else {
                IsRelevantToNewsLetter = false;
            }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateIsRelevantToNewsLetter",
                data: "{ StatusId:'" + StatusId + "', IsRelevantToNewsLetter:'" + IsRelevantToNewsLetter + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateIsRelevantToDelays(checkbox) {
            var row;
            var rowIndex;
            var StatusId;

            if (checkbox.id == "gvTargetAdmin_ctl02_chkDelays_freezeitem") {
                StatusId = 1;
            }
            else {
                row = checkbox.parentNode.parentNode;
                rowIndex = row.rowIndex - 1;
                StatusId = row.cells[1].getElementsByTagName("input")[0].value;
            }

            var IsRelevantToDelays = false;
            if (checkbox.checked) {
                IsRelevantToDelays = true;
            }
            else {
                IsRelevantToDelays = false;
            }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateIsRelevantToDelays",
                data: "{ StatusId:'" + StatusId + "', IsRelevantToDelays:'" + IsRelevantToDelays + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateDays(textbox, StatusId, ClientId, UserId) {
            var Days = document.getElementById(textbox.id).value;
            var hdnId = "hdn_" + StatusId + "_" + ClientId;

            //      if (Days == 0) {
            //        alert("Please enter some value for Days.");
            //        document.getElementById(textbox.id).value = $("#" + hdnId).val();
            //        return false;
            //      }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateDays",
                data: "{ StatusId:'" + StatusId + "', ClientId:'" + ClientId + "', Days:'" + Days + "', UserId:'" + UserId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
                document.getElementById(hdnId).value = Days;
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateDescription(textbox, StatusId) {
            //      debugger;
            var Description = document.getElementById(textbox.id).value;
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateTargetAdminDescription",
                data: "{ StatusId:'" + StatusId + "', Description:'" + Description + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function SavePermission(DropDownList, EmailId, ClientId, UserId) {
            var PermissionType = DropDownList;
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateEmailPermission",
                data: "{ EmailId: '" + EmailId + "', ClientId:'" + ClientId + "', PermissionType:'" + PermissionType + "', UserId:'" + UserId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateEmailPlan(DropDownList, EmailId) {
            var EmailPlanId = DropDownList;
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateEmailPlan",
                data: "{ EmailId: '" + EmailId + "', EmailPlanId:'" + EmailPlanId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
                SelectEmailPlan();
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }
        //abhishek 18/4/2016
        function UpdateEmailPerority(DropDownList, element, EmailId) {
            //      var oldValue = element.defaultValue;
            var EmailPlanId = DropDownList;
            if (EmailPlanId == '') {
                alert('Please enter order');
                element.value = element.defaultValue;
                return;
            }
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateEmailPerority",
                data: "{ EmailId: '" + EmailId + "', EmailPlanId:'" + EmailPlanId + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {

                if (response.d == 'Duplicate order cannot be added.') {
                    alert(response.d);
                    element.value = element.defaultValue;
                }
                else if (response.d == 'Priority updated.') {
                    alert(response.d);

                }
                else {
                    alert(response.d);
                    element.value = element.defaultValue;
                }
                //            alert(response.d);
                //            alert("Saved Sucessfully");
                //            SelectEmailPlan();
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }
        //abhishek on 22/4/2016
        function UpdateEmailIsGroup(DropDownList, EmailId) {
            //debugger;
            //        var EmailPlanId; 
            //        var $this = $(DropDownList);         
            //        if ($this.is(':checked')) {           
            //            EmailPlanId = 1;
            //        } else {
            //            EmailPlanId = 0;
            //        }

            // alert(EmailPlanId);
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateEmailIsGroup",
                data: "{ EmailId: '" + EmailId + "', EmailPlanId:'" + DropDownList + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
                SelectEmailPlan();
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function validate(evt) {
            //        var theEvent = evt || window.event;
            //        var key = theEvent.keyCode;
            //        key = String.fromCharCode(key);
            //        var regex = /[0-9]|\./;
            //        if (!regex.test(key)) {
            //            theEvent.returnValue = false;
            //            if (theEvent.preventDefault) theEvent.preventDefault();
            //        }
        }
        //end abhishek
        function UpdateEmailTime(DropDownList, EmailId) {
            var HoursId = "ddl_" + EmailId + "_Hours";
            var MinId = "ddl_" + EmailId + "_Min";
            var MeridianId = "ddl_" + EmailId + "_Meridian";

            var Hours = document.getElementById(HoursId).options[document.getElementById(HoursId).selectedIndex].text;
            var Min = document.getElementById(MinId).options[document.getElementById(MinId).selectedIndex].text;
            var Meridian = document.getElementById(MeridianId).options[document.getElementById(MeridianId).selectedIndex].text;

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateEmailTime",
                data: "{ EmailId: '" + EmailId + "', Hours:'" + Hours + "', Min:'" + Min + "', Meridian:'" + Meridian + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
                SelectEmailPlan();
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function UpdateEmailDays(CheckBox, EmailId) {
            var MonDay = "chk_" + EmailId + "_Monday";
            var TuesDay = "chk_" + EmailId + "_Tuesday";
            var WednesDay = "chk_" + EmailId + "_Wednesday";
            var ThrusDay = "chk_" + EmailId + "_Thursday";
            var FriDay = "chk_" + EmailId + "_Friday";
            var SaturDay = "chk_" + EmailId + "_Saturday";
            var SunDay = "chk_" + EmailId + "_Sunday";

            var Days = '';
            if (document.getElementById(MonDay).checked == true) {
                Days = 'Monday,';
            }
            if (document.getElementById(TuesDay).checked == true) {
                Days = Days + 'Tuesday,';
            }
            if (document.getElementById(WednesDay).checked == true) {
                Days = Days + 'Wednesday,';
            }
            if (document.getElementById(ThrusDay).checked == true) {
                Days = Days + 'Thursday,';
            }
            if (document.getElementById(FriDay).checked == true) {
                Days = Days + 'Friday,';
            }
            if (document.getElementById(SaturDay).checked == true) {
                Days = Days + 'Saturday,';
            }
            if (document.getElementById(SunDay).checked == true) {
                Days = Days + 'Sunday,';
            }

            Days = Days.replace(/,\s*$/, "");
            if (Days == '') {
                Days = 'Monday';
            }

            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateEmailDays",
                data: "{ EmailId: '" + EmailId + "', Days:'" + Days + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                alert("Saved Sucessfully");
                SelectEmailPlan();
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function OpenCopyFrom(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 200, width: 400, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }

        function OpenUpdatePredecessor(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }

        function OpenUpdateDesignation(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }

        function OpenUpdateStatusOrder(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 400, width: 600, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            $("#sb-nav-close").css({ "visibility": "hidden" });
            return false;
        }
        function SBClose() {

        }
    </script>
    <script type="text/javascript" src="../js/jquery-1.9.0-jquery.min.js"></script>
    <script src="../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        function BindEvents() {
            SelectEmailPlan();
            gridviewScroll();
        }

        function SelectEmailPlan() {
            var url = "../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/GetEmailPlanDetails",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });

            function OnSuccessCall(response) {
                var PlanId;
                var Hours;
                var Min;
                var Meridian;

                var MonDay, TuesDay, WednesDay, ThrusDay, FriDay, SaturDay, SunDay;

                for (var i = 0; i < response.d.length; i++) {
                    PlanId = "ddl_" + response.d[i]["EmailId"] + "_Plan";
                    Hours = "ddl_" + response.d[i]["EmailId"] + "_Hours";
                    Min = "ddl_" + response.d[i]["EmailId"] + "_Min";
                    Meridian = "ddl_" + response.d[i]["EmailId"] + "_Meridian";

                    MonDay = "chk_" + response.d[i]["EmailId"] + "_Monday";
                    TuesDay = "chk_" + response.d[i]["EmailId"] + "_Tuesday";
                    WednesDay = "chk_" + response.d[i]["EmailId"] + "_Wednesday";
                    ThrusDay = "chk_" + response.d[i]["EmailId"] + "_Thursday";
                    FriDay = "chk_" + response.d[i]["EmailId"] + "_Friday";
                    SaturDay = "chk_" + response.d[i]["EmailId"] + "_Saturday";
                    SunDay = "chk_" + response.d[i]["EmailId"] + "_Sunday";

                    document.getElementById(PlanId).value = response.d[i]["EmailPlanId"];

                    var j = 0;
                    for (j = 0; j < document.getElementById(Hours).options.length; j++) {
                        if (document.getElementById(Hours).options[j].text == response.d[i]["Hours"]) {
                            document.getElementById(Hours).selectedIndex = j;
                            break;
                        }
                    }

                    for (j = 0; j < document.getElementById(Min).options.length; j++) {
                        if (document.getElementById(Min).options[j].text == response.d[i]["Min"]) {
                            document.getElementById(Min).selectedIndex = j;
                            break;
                        }
                    }

                    for (j = 0; j < document.getElementById(Meridian).options.length; j++) {
                        if (document.getElementById(Meridian).options[j].text == response.d[i]["Meridian"]) {
                            document.getElementById(Meridian).selectedIndex = j;
                            break;
                        }
                    }

                    if (document.getElementById(PlanId).value == 1) // Hourly
                    {
                        document.getElementById(Hours).disabled = true;
                        document.getElementById(Min).disabled = false;
                        document.getElementById(Meridian).disabled = true;
                    }
                    else if (document.getElementById(PlanId).value == 2) // Daily
                    {
                        document.getElementById(Hours).disabled = false;
                        document.getElementById(Min).disabled = false;
                        document.getElementById(Meridian).disabled = false;
                    }
                    else if (document.getElementById(PlanId).value == 3) // Weekly
                    {
                        document.getElementById(Hours).disabled = false;
                        document.getElementById(Min).disabled = false;
                        document.getElementById(Meridian).disabled = false;
                    }

                    document.getElementById(MonDay).checked = false;
                    document.getElementById(TuesDay).checked = false;
                    document.getElementById(WednesDay).checked = false;
                    document.getElementById(ThrusDay).checked = false;
                    document.getElementById(FriDay).checked = false;
                    document.getElementById(SaturDay).checked = false;
                    document.getElementById(SunDay).checked = false;

                    var Days = response.d[i]["Days"].split(",");
                    for (var j = 0; j < Days.length; j++) {
                        if (MonDay.indexOf(Days[j]) > 0) {
                            document.getElementById(MonDay).checked = true;
                        }
                        else if (TuesDay.indexOf(Days[j]) > 0) {
                            document.getElementById(TuesDay).checked = true;
                        }
                        else if (WednesDay.indexOf(Days[j]) > 0) {
                            document.getElementById(WednesDay).checked = true;
                        }
                        else if (ThrusDay.indexOf(Days[j]) > 0) {
                            document.getElementById(ThrusDay).checked = true;
                        }
                        else if (FriDay.indexOf(Days[j]) > 0) {
                            document.getElementById(FriDay).checked = true;
                        }
                        else if (SaturDay.indexOf(Days[j]) > 0) {
                            document.getElementById(SaturDay).checked = true;
                        }
                        else if (SunDay.indexOf(Days[j]) > 0) {
                            document.getElementById(SunDay).checked = true;
                        }
                    }
                }
            }

            function OnErrorCall(response) {
                alert(response.status + " " + response.statusText);
            }
        }

        function gridviewScroll() {
            var gridWidth = $(window).width() - 5;
            var gridHeight = $(window).height() - 150;

            var gridFreezesize = 0;
            if ($('#rblHeader_0').is(':checked')) {
                gridFreezesize = 5
            }
            else {
                gridFreezesize = 2
            }

            $('#gvTargetAdmin').gridviewScroll({
                width: gridWidth,
                height: gridHeight,
                arrowsize: 30,
                varrowtopimg: "../images/arrowvt.png",
                varrowbottomimg: "../images/arrowvb.png",
                harrowleftimg: "../images/arrowhl.png",
                harrowrightimg: "../images/arrowhr.png",
                freezesize: gridFreezesize
            });
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function OpenAddNewClient(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 650, width: 1680, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        }

        function OpenDirectTask(obj) {
            var sURL = obj.href;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 500, width: 800, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
            return false;
        } 
 
    </script>
    <style type="text/css">
    .txt
    {
      font-family:Arial;
      color:#7E7E7E;
      text-transform:none;
      font-size: 11px !important;
    }
    #gvTargetAdmin td {
      height:100%;
    }
    div.scroll
    {
      background-color:#405D99;
      overflow-x:auto;
      white-space: nowrap;
      max-width:700px;
      min-width:500px;
      font-family:Arial;
      font-size:12px;
      color:#FFFFFF;
    }
    a {
      color:#405D99;
      text-decoration:none;
      font-family:Arial;
      font-size:13px;
    }
    a:hover {
      color:#405D99;
      text-decoration:underline;
      font-family:Arial;
      font-size:13px;
    }
    /**updated  css by bharat 3 jan 19*/
     div.scroll label
    {
        position:relative;
        top:-3px;
     }
     input[type="radio"]
     {
         position:relative;
         top:2px;
      }
      @-moz-document url-prefix() {
     input[type="radio"]
     {
        position:relative;
         top:0px;
      }
     }
    
      #gvTargetAdminCopyFreeze th
      {
          font-size:11px;
       
       }
      #gvTargetAdminHeaderCopy td
      {
        font-size:11px !important;  
      }
      #gvTargetAdminHeaderCopy th
      {
          border-color:#7a7a7a!important;
          }
      #gvTargetAdminFreeze td
      {
          font-size:10px !important;  
        }
        div
        {
            font-size:11px !important;
         }
        .GridCellDiv img
         {
                position: relative;
                top: 3px;
                left: 2px;
               
          }
             .GridCellDiv span
             {
                 font-size:11px !important;
              }
         /*end*/
            .submit {
        background: #13a747 !important;
        padding: 5px 9px;
        color: #fff;
        font-size: 13px;
        border: none !important;
        font-weight: bold;
        height: 24px;
        cursor:pointer;
    }
         .submit:hover {
        background: #13a747 !important;
        padding: 5px 9px;
        color: yellow;
        font-size: 13px;
        border: none !important;
        font-weight: bold;
        height: 24px;
    }
     #secure_banner_cor
     {
         padding:0px 0px;
      } 
      a.buttonColor
      {
            color: #fff;
            text-decoration: none;
            font-family: Arial;
            font-size: 12px;
            background: #405D99;
            padding: 5px 7px;
       }  
         a.buttonColor:hover
      {
            color: yellow;
       }  
  </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="smTargetAdmin" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upTargetAdmin" runat="server">
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(BindEvents);
                </script>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" style="font-family: Arial;">
                    <tr>
                        <td align="center" style="background-color: #405D99; height: 31px; color: #FFFFFF;
                            font-size: 18px; font-family: Arial;">
                            <asp:RadioButtonList ID="rblHeader" runat="server" RepeatDirection="Horizontal" Width="700px"
                                AutoPostBack="true" OnSelectedIndexChanged="rblHeader_SelectedIndexChanged">
                                <asp:ListItem Value="1" Text="Target Date Admin" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Email Notification"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Direct Task"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table border="0" cellpadding="0" cellspacing="0" width="1465px" align="left">
                                <tr>
                                    <td align="left" valign="middle" style="width: 420px; padding-left: 25px; font-size: 13px !important">
                                        <asp:DropDownList ID="ddlClients" runat="server" CssClass="txt" Width="375px" Font-Size="13px"
                                            Style="font-size: 12px !important" ForeColor="#405D99" AutoPostBack="true" OnSelectedIndexChanged="ddlClients_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="1" Text="For Client with Order from New Order to Ex-Factory"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="All Clients with Order"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="All Clients without Order"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" valign="middle" style="width: 25px;">
                                        <asp:CheckBox ID="chkAllClients" runat="server" Checked="true" AutoPostBack="true"
                                            OnCheckedChanged="chkAllClients_CheckedChanged" />
                                    </td>
                                    <td style="width: 700px; height: 60px; padding-left: 15px;">
                                        <div id="divFilter" class="scroll">
                                            <asp:CheckBoxList ID="chkFilteredClient" runat="server" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                        </div>
                                    </td>
                                    <td align="center" style="width: 90px; height: 60px;">
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="do-not-include submit" Text="Submit"
                                            OnClick="btnSubmit_Click" />
                                    </td>
                                    <td style="width: 200px; height: 60px;text-align:left">
                                        <a rel="shadowbox;width=1250;height=650;" href="../Internal/Client/clientedit.aspx"
                                            onclick='return OpenAddNewClient(this);' class="buttonColor">Add New Client</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 1px; box-shadow: 6px 2px 4px 1px #00000047;">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="upTargetAdmin"
                                DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                                        z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:GridView ID="gvTargetAdmin" runat="server" AutoGenerateColumns="false" HeaderStyle-Height="35px"
                                HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF"
                                HeaderStyle-BackColor="#405D99" RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"
                                OnRowDataBound="gvTargetAdmin_RowDataBound" RowStyle-VerticalAlign="Middle">
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvDirectTasks" runat="server" AutoGenerateColumns="false" HeaderStyle-Height="35px"
                                HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF"
                                HeaderStyle-BackColor="#405D99" RowStyle-Height="35px" RowStyle-ForeColor="#7E7E7E"
                                OnRowDataBound="gvDirectTasks_RowDataBound" RowStyle-VerticalAlign="Middle">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="200px">
                                                <tr>
                                                    <td align="center" style="background-color: #405D99; color: #FFFFFF;">
                                                        Status
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" CssClass="txt" Font-Size="12px" Text='<%#Eval("StatusModeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                        HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="250px">
                                                <tr>
                                                    <td align="center" style="background-color: #405D99; color: #FFFFFF;">
                                                        Designation
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
