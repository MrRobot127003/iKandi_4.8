<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true"
    CodeBehind="OrderProcessFlow.aspx.cs" Inherits="iKandi.Web.Internal.OrderProcessing.OrderProcessFlow" %>

<%@ Register Src="~/UserControls/Forms/Fitting.ascx" TagName="Fitting" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Forms/RiskAnalysis.ascx" TagName="RiskAnalysis"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Forms/OrderProcessOB.ascx" TagName="OB" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Forms/HOPPM.ascx" TagName="HOPPM" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <%--<script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>--%>
    <link href="../../js/Calender-css1.css" rel="stylesheet" type="text/css" />
    <script src="../../js/Calender_new.js" type="text/javascript"></script>
    <script src="../../js/Calender_new2.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../CommonJquery/Js/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
    <%--<link href="../../App_Themes/ikandi/technical-module.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="../AspxPageJS/OrderProcessFlow.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        $(function () {
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });

        });
  
    </script>
    <script type="text/javascript">
 
    </script>
    <style type="text/css">
        .divhide
        {
           style="display: none";
        }
 
       
        .wrapper ul li a
        {
            background:#39589c !important;
             color: #fff !important;
        }
        

        .fittingcontainer {
            background-color: #0868C2 !important;
           color:#fff !important;
        }
        /*added by bharat*/
        input[type="checkbox"]
        {
            position:relative;
            top:3px;
            right: 2px;
         }
        
         input[type=text] {
             font-size: 11px !important;}
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Basic Information</title>
        <meta http-equiv="X-UA-Compatible" content="IE=10; IE=EDGE" />
        <link href="../../css/demostyles.css" rel="stylesheet" type="text/css" />
        <link href="../../css/report.css" rel="stylesheet" type="text/css" />
  
        <script type="text/javascript">
            //    var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
            //    var proxy = new ServiceProxy(serviceUrl);
            var tab = 1;
            var whichtab;


            jQuery(function ($) {

                //          $.noConflict();
                $(".tab1").css("display", "block");
                $(".tab2").css("display", "block");
                $(".tab3").css("display", "block");
                $(".tab4").css("display", "block");
                //$("input.thisdate", "#main_content").datepicker({ dateFormat: 'dd M y (D)', buttonImage: 'App_Themes/ikandi/images/calendar.gif' });

                var styleId = GetParameterValues('styleid');
                var stylenumber = GetParameterValues('stylenumber');
                var hdnval = $('#<%= hdnTab.ClientID %>').val();
                var CheckForm = $('#<%= hdnShowForm.ClientID %>').val();
                var IsOBForm = $('#<%= hdnIsOBForm.ClientID %>').val();
                var IsFitsForm = $('#<%= hdnIsFitsForm.ClientID %>').val();
                var IsRiskForm = $('#<%= hdnIsRiskForm.ClientID %>').val();
                var IsHOPPMForm = $('#<%= hdnIsHOPPMForm.ClientID %>').val();

                if ((tab == 1) && (hdnval == 0) && (CheckForm == '0')) {
                    //debugger;           
                    $('.riskanalysis').show();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('#<%= hdnTab.ClientID %>').val(1);
                    whichtab = 1;
                    CheckOrderProcess(styleId, whichtab);
                    $('.tab1').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab1').css('color', 'black');
                    $('.tab1').css('background-color', 'white');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');
                }
                if ((tab == 1) && (hdnval == 1)) {
                    //debugger;
                    $('.riskanalysis').show();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('.tab1').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab1').css('color', 'black');
                    $('.tab1').css('background-color', 'white');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');
                }
                if ((hdnval == 1) && (IsRiskForm == 0)) {
                    //debugger;
                    $('.riskanalysis').show();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('.tab1').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab1').css('color', 'black');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');

                }

                if ((hdnval == 1) && (IsHOPPMForm == 0)) {
                    //debugger;
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').show();
                    $('.OB').hide();
                    $('.tab4').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab4').css('color', 'black');
                    $('.tab1').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab1').css('color', 'white');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');

                }

                if ((hdnval == 2) && (IsFitsForm == 0)) {
                    //debugger;
                    $('.riskanalysis').hide();
                    $('.fitting').show();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('.tab2').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab2').css('color', 'black');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');
                    $('.tab1').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab1').css('color', 'white');
                }
                if ((hdnval == 3) && (IsOBForm == 0)) {
                    //debugger;
                    $('.OB').show();
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.tab3').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab3').css('color', 'black');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab1').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab1').css('color', 'white');
                }
                if (hdnval == 4) {
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').show();
                    $('.OB').hide();
                    $('.tab4').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab4').css('color', 'black');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab1').css('background-image', 'url("../../images/currentbg.gif")');

                }

                if (IsRiskForm == '1') {
                    //debugger;
                    $('.tab1').show();
                    $('.tab2').hide();
                    $('.tab3').hide();
                    $('.tab4').hide();
                    $('.tab1').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab1').css('color', 'black');
                    $('.riskanalysis').show();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').hide();
                }

                if (IsHOPPMForm == '1') {
                    //debugger;
                    $('.tab1').hide();
                    $('.tab2').hide();
                    $('.tab3').hide();
                    $('.tab4').show();
                    $('.tab4').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab4').css('color', 'black');
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').show();
                    $('.OB').hide();
                }

                if (IsOBForm == '1') {
                    //debugger;
                    $('.tab1').hide();
                    $('.tab2').hide();
                    $('.tab3').show();
                    $('.tab4').hide();
                    $('.tab3').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab3').css('color', 'black');
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').show();
                }

                if (IsFitsForm == '1') {
                    //debugger;
                    $('.tab1').hide();
                    $('.tab2').show();
                    $('.tab3').hide();
                    $('.tab4').hide();
                    $('.tab2').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab2').css('color', 'black');
                    $('.riskanalysis').hide();
                    $('.fitting').show();
                    $('.hoppm').hide();
                    $('.OB').hide();
                }

                if (CheckForm == 'ShowRiskForm') {
                    //debugger;
                    $('.tab1').show();
                    $('.tab2').hide();
                    $('.tab3').hide();
                    $('.tab4').hide();
                    $('.tab1').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab1').css('color', 'black');
                    $('.riskanalysis').show();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('#<%= hdnTab.ClientID %>').val(1);
                    whichtab = 1;
                    CheckOrderProcess(styleId, whichtab);
                    $('#<%= hdnShowForm.ClientID %>').val('0');
                    $('#<%= hdnIsRiskForm.ClientID %>').val('1');
                }

                if (CheckForm == 'ShowHOPPMForm') {
                    //debugger;
                    $('.tab1').hide();
                    $('.tab2').hide();
                    $('.tab3').hide();
                    $('.tab4').show();
                    $('.tab4').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab4').css('color', 'black');
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').show();
                    $('.OB').hide();
                    $('#<%= hdnTab.ClientID %>').val(4);
                    whichtab = 4;
                    CheckOrderProcess(styleId, whichtab);
                    $('#<%= hdnShowForm.ClientID %>').val('0');
                    $('#<%= hdnIsHOPPMForm.ClientID %>').val('1');
                }

                if (CheckForm == 'ShowFitsForm') {
                    //debugger;
                    $('.tab1').hide();
                    $('.tab2').show();
                    $('.tab3').hide();
                    $('.tab4').hide();
                    $('.tab2').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab2').css('color', 'black');
                    $('.riskanalysis').hide();
                    $('.fitting').show();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('#<%= hdnTab.ClientID %>').val(2);
                    whichtab = 2;
                    CheckOrderProcess(styleId, whichtab);
                    $('#<%= hdnShowForm.ClientID %>').val('0');
                    $('#<%= hdnIsFitsForm.ClientID %>').val('1');
                }
                if (CheckForm == 'ShowOBForm') {
                    //debugger;
                    $('.tab1').hide();
                    $('.tab2').hide();
                    $('.tab3').show();
                    $('.tab4').hide();
                    $('.tab3').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab3').css('color', 'black');
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').show();
                    $('#<%= hdnTab.ClientID %>').val(3);
                    whichtab = 3;
                    CheckOrderProcess(styleId, whichtab);
                    $('#<%= hdnShowForm.ClientID %>').val('0');
                    $('#<%= hdnIsOBForm.ClientID %>').val('1');
                }

                $('.tab1').click(function () {
                    //debugger;
                    $('.riskanalysis').show();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('#<%= hdnTab.ClientID %>').val(1);
                    whichtab = 1;
                    CheckOrderProcess(styleId, whichtab);
                    $('.tab1').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab1').css('color', 'black');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');
                });

                $('.tab2').click(function () {
                    //debugger;
                    $('.riskanalysis').hide();
                    $('.fitting').show();
                    $('.hoppm').hide();
                    $('.OB').hide();
                    $('#<%= hdnTab.ClientID %>').val(2);
                    whichtab = 2;
                    CheckOrderProcess(styleId, whichtab);
                    $('.tab2').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab2').css('color', 'black');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');
                    $('.tab1').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab1').css('color', 'white');
                });

                $('.tab3').click(function () {
                    // debugger;
                    $('.OB').show();
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').hide();
                    $('#<%= hdnTab.ClientID %>').val(3);
                    whichtab = 3;
                    CheckOrderProcess(styleId, whichtab);
                    $('.tab3').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab3').css('color', 'black');
                    $('.tab4').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab4').css('color', 'white');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab1').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab1').css('color', 'white');
                });

                $('.tab4').click(function () {
                    // debugger;
                    $('.OB').hide();
                    $('.riskanalysis').hide();
                    $('.fitting').hide();
                    $('.hoppm').show();
                    $('#<%= hdnTab.ClientID %>').val(4);
                    whichtab = 4;
                    CheckOrderProcess(styleId, whichtab);
                    $('.tab4').css('background-image', 'url("../../images/change_bg.gif")');
                    $('.tab4').css('color', 'black');
                    $('.tab2').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab2').css('color', 'white');
                    $('.tab3').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab3').css('color', 'white');
                    $('.tab1').css('background-image', 'url("../../images/currentbg.gif")');
                    $('.tab1').css('color', 'white');


                });


            });

            function GetParameterValues(param) {
                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        return urlparam[1];
                    }
                }
            }

            function CheckOrderProcess(styleId, whichtab) {
                //alert('1');
                //debugger;
                var ClientId = $('#<%= hdnClientId.ClientID %>').val();
                var DeptId = $('#<%= hdnDeptId.ClientID %>').val();
                proxy.invoke("CheckOrderProcess", { Styleid: styleId, ClientId: ClientId, DeptID: DeptId, Whichtab: whichtab },
        function (result) {
            //debugger;
            //alert(result.length);
            if (result.length > 0) {
                //alert(result.length);

                //debugger;               
                var url = 'OrderProcessPopup.aspx?styleid=' + styleId + '&ClientId=' + ClientId + '&DeptId=' + DeptId + '&Tab=' + whichtab + '';
                var popupWindow = window.open(url, '_blank', 'height=200,width=600,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=no,resizable=no, screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
                window.document.body.disabled = true;
                //                $("#OrderProcessPopup").attr("href", "OrderProcessPopup.aspx?styleid=" + styleId + '&ClientId=' + ClientId + '&DeptId=' + DeptId + '&Tab=' + whichtab);
                //                $('#OrderProcessPopup').click();

            }

        }, null, false, false);
            };


   
        </script>
        <script src="../../js/combined_jquery_scripts4.js" type="text/javascript"></script>
        <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
            function OpenConversationShadowbox(obj) {
                var sURL = obj.href;
                Shadowbox.init({ animate: true, animateFade: true, modal: true });
                Shadowbox.open({ content: sURL, type: "iframe", player: "iframe", title: "", height: 250, width: 550, modal: true, animate: true, animateFade: true, options: { onClose: SBClose} });
                $("#sb-nav-close").css({ "visibility": "hidden" });
                return false;
            }
            function SBClose() { }
        </script>
    </head>
    <body>
        <script src="../../js/jquery.tabbedcontent.min.js" type="text/javascript"></script>
        <div class="fittingcontainer2">
            <table width="100%" cellpadding="0" border="0" cellspacing="0">
                <tr>
                    <td style="width: 98%;">
                        <a id="OrderProcessPopup" rel="shadowbox;width=550;height=250;" onclick="return OpenConversationShadowbox(this);"
                            style="font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px;">
                        </a>
                        <asp:HiddenField ID="hdnClientId" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnDeptId" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnShowForm" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnIsOBForm" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnIsFitsForm" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnIsRiskForm" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnIsHOPPMForm" Value="0" runat="server" />
                        <div class="wrapper ">
                            <ul>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <li><a runat="server" id="lnkRisk" class="tab1">Risk Analysis</a></li>
                                <li><a runat="server" id="lnkFit" class="tab2">Fitting</a></li>
                                <%--abhishek--%>
                                <li><a runat="server" id="lnkOB" class="tab3">SAM OB W/S</a></li>
                                <%--end--%>
                                <li><a runat="server" id="lnkHO" class="tab4">HOPPM</a></li>
                                <%--<li><a class="tab5" href="#tab-5">QA Production</a></li>           --%>
                            </ul>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 98%;">
                        <div class="tabscontent tab-content">
                            <asp:HiddenField ID="hdnTab" Value="0" runat="server" />
                            <div runat="server" id="tabRisk" class="riskanalysis">
                                <uc1:RiskAnalysis ID="RiskAnalysis" runat="server" />
                            </div>
                            <div runat="server" id="tabFit" class="fitting">
                                <uc2:Fitting ID="Fitting" runat="server" />
                            </div>
                            <div runat="server" id="tabOB" class="OB">
                                <uc3:OB ID="OB" runat="server" />
                            </div>
                            <div runat="server" id="tabHO" class="hoppm">
                                <uc4:HOPPM ID="HOPPM" runat="server" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="dialog1" class="compopup dialog" style="display: none">
            <div id="popupselection" class="popupselection">
                <table>
                    <tr>
                        <td>
                            <p class="CreateNew">
                                CreateNew</p>
                        </td>
                        <td>
                        </td>
                        <td>
                            <p class="Reuse">
                                Reuse</p>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="popupreuse" class="popupreuse divhide">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <p>
                                Select Style Number</p>
                        </td>
                        <td>
                            <select class="Usedstylelst">
                                <option value="0">Select Style Number</option>
                            </select>
                        </td>
                        <td>
                            <p class="ReuseStyle ">
                                Reuse Selected Style Number</p>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </body>
    </html>
</asp:Content>
