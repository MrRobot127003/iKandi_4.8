<%@ Page Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="ProductOccupationalSafetyAudit.aspx.cs" Inherits="iKandi.Web.Internal.Qc_Complience.ProductOccupationalSafetyAudit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src="../../js/jquery-1.11.0.min.js"></script>
    <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <script src="../../js/combined_jquery_scripts4.js" type="text/javascript"></script>
    <script src="../../js/form.js" type="text/javascript"></script>
     <link href="../../css/report.css" rel="stylesheet" type="text/css" />
<%--      <script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
    <script src="../../css/gridviewScroll.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">


        function OpenLineProcessAudit(obj) {
            // debugger;
            var UnitId = $(obj).children('.UnitId').val();
            // alert(UnitId); LineNo
            var ProcessType = $(obj).children('.ProcessType').val();
            var InternalAuditId = $(obj).children('.InternalAuditId').val();
            var QAcompilation = $(obj).children('.QAcompilation').val();
            var ValueId = $(obj).children('.ValueId').val();
            var LineNo = $(obj).children('.LineNo').val();
            var LineName = $(obj).children('.LineName').val();
            var CompareDate = $(obj).children('.CompareDate').html();


            var sURL = 'Line_Process_Audit_Comment_Decision.aspx?UnitId=' + UnitId + '&InternalAuditId=' + InternalAuditId + '&ProcessType=' + ProcessType + '&QAcompilation=' + QAcompilation + '&ValueId=' + ValueId + '&LineNo=' + LineNo + '&CompareDate=' + CompareDate + '&LineName=' + LineName;
            Shadowbox.init({ animate: true, animateFade: true, modal: true });
            Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 300, width: 450, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });

            return false;
        }
        function SBClose() { }

        function CallRefresh() {
            debugger;
            $.showprogress();
            $("#processing_container").css('style', 'min-width: 300px !important;max-width: 100px; !important');
            ////            var obj = {};      
            ////            var qrStr = window.location.search;
            ////            var qrStr1 = qrStr.split("?")[1].split("=")[1];
            ////            var ProcessType = qrStr1.split("&")[0];
            ////            var Unitid = qrStr.split("?")[1].split("=")[2];
            ////            var newdate = $('#ctl00_cph_main_content_dateSelect').val();
            ////            obj.ProcessType = ProcessType;
            ////            obj.Unitid = Unitid;
            ////            obj.newDate = newdate;
            ////            $.ajax({
            ////                type: "POST",
            ////                url: "ProductOccupationalSafetyAudit.aspx/CallRefresh",
            ////                data: JSON.stringify(obj),
            ////                contentType: "application/json; charset=utf-8",
            ////                dataType: "json",
            ////                success: OnSuccess,
            ////                failure: function (response) {
            ////                    alert(response.d);
            ////                }
            ////            });
            //            var url = window.location.href;
            //            if (url.indexOf("?") > 0) {
            //                url = url.substring(0, url.indexOf("?"));
            //            }
            //            url += "?joined=true";
            //            window.location.replace(url);
            location.reload();
            //$(".btnthisFits").click();
           // $("#processing_container").css('style', 'min-width: 300px !important;max-width: 100px; !important');
//            $.hideprogress();

        }
        function OnSuccess(response) {
            // debugger;
            $(".ShowDiv").empty();
            $(".ShowDiv").html(response.d);
            ShowImagePreview();
        }
    </script>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            ShowImagePreview();
            // var devliaryj = jQuery.noConflict();

            var UnitId = $('.UnitId').val();        // alert(UnitId); //LineNo
            var ProcessType = $('.ProcessType').val();
            // var showdates = 0;
            var futuredate = 0;
            //        var minDate=3;
            //        var d = new Date();
            //        var TodayDate = d.getDate();
            //        if (TodayDate > 5) {
            //            minDate = TodayDate-1;
            //        }

            if (UnitId == -1 && ProcessType == -1) {
                //showdates = -3;
                futuredate = -1;
            }

            $(".th").datepicker({
                dateFormat: 'dd M y',
                minDate: -20,
                maxDate: futuredate
            });

            //$("#processing_container").css('style', 'width:200px !important');
            document.getElementById("processing_overlay").style.height = "50px";
            //alert('ff');

            //            $("#processing_container").css({
            //                position: pos,
            //                zIndex: 99999,
            //                padding: 0,
            //                margin: 0,
            //                width:
            //            });

        });
        // Configuration of the x and y offsets
        function ShowImagePreview() {
            xOffset = 250;
            yOffset = 1300;
            $(".preview").hover(function (e) {
                this.t = this.title;
                this.title = "";
                var c = (this.t != "") ? "<br/>" + this.t : "";
                $("body").append("<p id='preview'><img src='" + this.src + "' alt='Image preview' style='height:400px !important; width:300px !important;'/>" + c + "</p>");
                $("#preview")
            .css("top", "10%")
            .css("left", "30%")
            .fadeIn("slow");
            },

function () {
    this.title = this.t;
    $("#preview").remove();
});

            $(".preview").mousemove(function (e) {
                $("#preview")
            .css("top", "10%")
            .css("left", "30%")
            });
        };


        function Change() {
            //  debugger;
            $(".submit").click();

            $(".th").datepicker({
                dateFormat: 'dd M y',
                minDate: -20,
                maxDate: futuredate
            });
        }

//        function gridviewScroll() {
//            debugger;
//            var gridWidth = $('#main_content').width();
//            var gridHeight = $('#main_content').height() + 10;
//            $('.headertopfixed').gridviewScroll({
//                width: gridWidth,
//                height: gridHeight,
//                freezesize: 1
//            });
//        }
    </script>
    <style type="text/css">
        body
        {
            font-size: 11px;
        }
        
        #preview
        {
            /* position: absolute;*/
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        .mainheader
        {
            padding: 9px 0px;
            background: #dddfe4 !important;
            color: #575759 !important;
            font-size: 12px;
            text-align: center;
            margin: 0px auto;
            border:1px solid #999;
            border-bottom:0px;
            width:100%!important;
        }
        .AddClass_Table th
        {
            background: #dddfe4 !important;
        }
         .AddClass_Table td
        {
            padding:2px 5px;
            color: #666565;
            line-height: 15px;
        }
        .preview
        {
            display: none;
        }
       
        #processing_container
        {
            font: bold 14px verdana;
            min-width: 100px;
            max-width: 100px;
            background: #FFF;
            border: solid 5px #00303f;
            color: #00303f;
        }
       
        #main_content
        {
            overflow: auto;
         }
         ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }
        .da_submit_button {
            margin-bottom: 5px;
        }
       @media only screen and (max-width: 1366px) {
        #main_content
        {
             min-width: 1340px;
            overflow: auto;
         }
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <h2 runat="server" id="mainhead" class="mainheader">
        <div style='float: left; margin-left: 10px;'>
            <asp:TextBox ID="dateSelect" runat="server" onchange="Change();" class="th"></asp:TextBox>
            &nbsp;
           <%-- <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="submit" OnClick="Go_Click"
                Style="display: none;" />--%>
        </div>
        <asp:Label runat="server" ID="lblProcessName" Text=""></asp:Label>
    </h2>
    <asp:UpdatePanel ID="pnlupdate" runat="server">
        <ContentTemplate>
         <script type="text/javascript">
             Sys.Application.add_load(PageLoad);
        </script>
            <div runat="server" id="ProductOccuPational" class="ShowDiv">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnRefresh" runat="server" OnClientClick="javascript:CallRefresh()"
        Text="Reload page" CssClass="go da_submit_button" />
    <%-- <script type="text/javascript" src="https://www.jqueryscript.net/demo/Smart-Customizable-jQuery-Media-Viewer-Plugin-Shadowbox/shadowbox.js">    </script>--%>
</asp:Content>
