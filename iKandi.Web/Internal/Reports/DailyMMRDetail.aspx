<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/layout/Secure.Master" CodeBehind="DailyMMRDetail.aspx.cs" Inherits="iKandi.Web.Internal.Reports.DailyMMRDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <style type="text/css">
        .header1 td {
            background-color: #e6e6e6;
            color: #575759 !important;
            font-size: 11px;
            border: 1px solid #999;
        }
        .style1 {
            width: 12%;
        }
        .style2 {
            width: 21%;
        }
        .style3 {
            width: 22%;
        }
        .font {
            font-size: 13px;
        }
        
        .select-con {
            font-size: 12px;
            line-height: 20px !important;
        }
        .select-con option {
            background: #fff;
            font-size: 14px !important;
            font-family: verdana;
            color: #000;
            line-height: 20px !important;
            padding-bottom: 5px;
        }
        #main_content {
            text-transform: capitalize !important;
        }
        /*-------------------------9-nov-2015------------------------- */
        .main_tbl_wrapper {
            background: #ffffff;
        }
        
        td {
            font-size: 11px;
            padding: 3px 2px;
            text-align: center;
        }
        .border td {
            font-size: 10px !important;
        }
        .heading-bg {
            padding: 10px 3px !important;
        }
        .border2 th {
            padding: 2px !important;
        }
        .font {
            font-size: 12px !important;
        }
        #secure_banner_cor {
            background: none !important;
        }
        #grdMMReport td {
            text-align: center;
            width: 70px;
        }
        #grdMMReport td input[type='text'] {
            text-align: center;
            color: blue;
            width: 89% !important;
            font-size: 11px;
        }
        td input[type='text'] {
            text-align: center;
        }
        #grdBudgetShortfall td input[type='text'] {
            text-align: center;
            font-size: 11px;
        }
        .tadayBackColor {
            background: #DCE6F1;
        }
        
        .TodayBackColorYellow {
            background: yellow;
        }
        .minWithFis {
            min-width: 130px;
            max-width: 130px;
        }
        #secure_banner_cor {
            padding: 0px;
        }
    </style>
    <%--<link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />--%>
    <script src="../../js/Calender_new.js" type="text/javascript"></script>
    <script src="../../js/Calender_new2.js" type="text/javascript"></script>
    <script type="text/javascript">

        //        function ResetAllControl() {
        //            $('#btnSave').click(function () {
        //                alert("Hello");
        //                $('#form1').each(function () {
        //                    this.reset();
        //                });
        //            });
        //        }



        function MRTDailyScrolltop() {
            //debugger;

            $("html, body").animate({
                scrollTop: 0
            }, 600);
            return false;
        }

        //added by raghvinder on 18-05-2020 starts
        function CalculateFinancialBIPL(elem) {
            //debugger;
            //var txtBIPLValue = elem.value;
            var txtManPowerBudget = elem.value;
            var objId = elem.id.split("_")[5].substr(3);
            var gridID = elem.id.split("_")[4];
            var gridIDLast = elem.id.split("_")[6];

            //            var objId = elem.id.split("_")[1].substr(3);
            //            var gridID = elem.id.split("_")[0];
            //            var gridIDLast = elem.id.split("_")[2];

            if (gridIDLast == 'txtManPowerBudgetC47') {
                financialLable = '_lbFinancialBudgetC47';
            }
            else if (gridIDLast == 'txtManPowerTodayC47') {
                financialLable = '_lblFinancialTodayC47';
            }

            else if (gridIDLast == 'txtManPowerBudgetC45') {
                financialLable = '_lbFinancialBudgetC45';
            }

            else if (gridIDLast == 'txtManPowerTodayC45') {
                financialLable = '_lblFinancialTodayC45';
            }
            else if (gridIDLast == 'txtManPowerBudgetD169') {
                financialLable = '_lbFinancialBudgetD169';
            }

            else if (gridIDLast == 'txtManPowerTodayD169') {
                financialLable = '_lblFinancialTodayD169';
            }


            //            else if (gridIDLast == 'txtManPowerBudgetC52') {
            //                financialLable = '_lbFinancialBudgetC52';
            //            }

            //            else if (gridIDLast == 'txtManPowerTodayC52') {
            //                financialLable = '_lblFinancialTodayC52';
            //            }


            else if (gridIDLast == 'txtManPowerBudgetBIPL') {
                financialLable = '_lbFinancialBudgetBIPL';
            }

            else if (gridIDLast == 'txtManPowerTodayBIPL') {
                financialLable = '_lblFinancialTodayBIPL';
            }

            var gridIDFull = "'" + '#' + elem.id + "'";

            var ID = elem.id.split("_")[5].substr(3);

            var Salary = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_hdnSalary").value;
            var IsStatus = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_hdnIsStatus").value;
            //            var total_OT_Hours = document.getElementById("hdnTotalOTHours").value;
            //            var working_days = document.getElementById("hdnworkingdays").value;
            //            var OT = document.getElementById("hdnOT").value;
            //            var working_hours = document.getElementById("hdnworkinghour").value;
            //            var multiplier = document.getElementById("hdnmultiplier").value;

            var total_OT_Hours = $("#ctl00_cph_main_content_hdnTotalOTHours").val();
            var working_days = $("#ctl00_cph_main_content_hdnworkingdays").val();
            var OT = $("#ctl00_cph_main_content_hdnOT").val();

            var working_hours = $("#ctl00_cph_main_content_hdnworkinghour").val();
            var multiplier = $("#ctl00_cph_main_content_hdnmultiplier").val();
            //var multiplier = 1.108;

            var C47Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetC47").value;
            var C47Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayC47").value;

            var C45Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetC45").value;
            var C45Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayC45").value;

            var D169Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetD169").value;
            var D169Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayD169").value;

            //            var C52Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetC52").value;
            //            var C52Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayC52").value;

            var txtBIPLSum = 0;
            if (gridIDLast == 'txtManPowerBudgetBIPL') {
                //                txtBIPLSum = (C47Budget == '' ? 0 : parseInt(C47Budget)) + (C45Budget == '' ? 0 : parseInt(C45Budget)) + (D169Budget == '' ? 0 : parseInt(D169Budget)) + (C52Budget == '' ? 0 : parseInt(C52Budget));
                txtBIPLSum = (C47Budget == '' ? 0 : parseInt(C47Budget)) + (C45Budget == '' ? 0 : parseInt(C45Budget)) + (D169Budget == '' ? 0 : parseInt(D169Budget));
            }
            if (gridIDLast == 'txtManPowerTodayBIPL') {
                //                txtBIPLSum = (C47Today == '' ? 0 : parseInt(C47Today)) + (C45Today == '' ? 0 : parseInt(C45Today)) + (D169Today == '' ? 0 : parseInt(D169Today)) + (C52Today == '' ? 0 : parseInt(C52Today));
                txtBIPLSum = (C47Today == '' ? 0 : parseInt(C47Today)) + (C45Today == '' ? 0 : parseInt(C45Today)) + (D169Today == '' ? 0 : parseInt(D169Today));
            }

            if (IsStatus == 'False') {
                var financialbudget
                if (parseInt(txtManPowerBudget) > txtBIPLSum) {
                    financialbudget = parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtManPowerBudget));
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtManPowerBudget);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtManPowerBudget);
                    }
                }
                else {
                    financialbudget = parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtBIPLSum));
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {
                        //                        $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtBIPLSum);
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(parseInt(txtBIPLSum) == 0 ? "" : txtBIPLSum);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(parseInt(txtBIPLSum) == 0 ? "" : txtBIPLSum);
                    }
                }

                if (financialbudget != 0) {
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,'));

                }
                else {
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text('');
                }
            }
            else {

                var financialbudget
                if (parseInt(txtManPowerBudget) > txtBIPLSum) {
                    financialbudget = (parseFloat(Salary) + ((parseFloat(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * parseFloat(txtManPowerBudget);
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtManPowerBudget);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtManPowerBudget);
                    }
                }
                else {
                    financialbudget = (parseFloat(Salary) + ((parseFloat(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * parseFloat(txtBIPLSum);
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(parseInt(txtBIPLSum) == 0 ? "" : txtBIPLSum);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(parseInt(txtBIPLSum) == 0 ? "" : txtBIPLSum);
                    }
                }

                if (financialbudget != 0) {
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,'));
                }
                else {
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text('');
                }
            }
        }

        function CalculateFinancials(elem) {
            //debugger;
            var financialLable = '';
            var txtManPowerBudget = elem.value;

            var objId = elem.id.split("_")[5].substr(3);
            var gridID = elem.id.split("_")[4];
            var gridIDLast = elem.id.split("_")[6];

            if (gridIDLast == 'txtManPowerBudgetC47') {
                financialLable = '_lbFinancialBudgetC47';
            }
            else if (gridIDLast == 'txtManPowerTodayC47') {
                financialLable = '_lblFinancialTodayC47';
            }

            else if (gridIDLast == 'txtManPowerBudgetC45') {
                financialLable = '_lbFinancialBudgetC45';
            }

            else if (gridIDLast == 'txtManPowerTodayC45') {
                financialLable = '_lblFinancialTodayC45';
            }
            else if (gridIDLast == 'txtManPowerBudgetD169') {
                financialLable = '_lbFinancialBudgetD169';
            }

            else if (gridIDLast == 'txtManPowerTodayD169') {
                financialLable = '_lblFinancialTodayD169';
            }

            //            else if (gridIDLast == 'txtManPowerBudgetC52') {
            //                financialLable = '_lbFinancialBudgetC52';
            //            }

            //            else if (gridIDLast == 'txtManPowerTodayC52') {
            //                financialLable = '_lblFinancialTodayC52';
            //            }

            else if (gridIDLast == 'txtManPowerBudgetBIPL') {
                financialLable = '_lbFinancialBudgetBIPL';
            }

            else if (gridIDLast == 'txtManPowerTodayBIPL') {
                financialLable = '_lblFinancialTodayBIPL';
            }

            var gridIDFull = "'" + '#' + elem.id + "'";

            var ID = elem.id.split("_")[5].substr(3);

            var Salary = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_hdnSalary").value;
            var IsStatus = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_hdnIsStatus").value;
            //            var total_OT_Hours = document.getElementById("hdnTotalOTHours").value;
            //            var working_days = document.getElementById("hdnworkingdays").value;
            //            var OT = document.getElementById("hdnOT").value;
            //            var working_hours = document.getElementById("hdnworkinghour").value;
            //            var multiplier = document.getElementById("hdnmultiplier").value;


            var total_OT_Hours = $("#ctl00_cph_main_content_hdnTotalOTHours").val();
            var working_days = $("#ctl00_cph_main_content_hdnworkingdays").val();
            var OT = $("#ctl00_cph_main_content_hdnOT").val();

            //var working_hours = $("#ctl00_cph_main_content_hdnTotalOTHours").val();
            var working_hours = $("#ctl00_cph_main_content_hdnworkinghour").val();
            var multiplier = $("#ctl00_cph_main_content_hdnmultiplier").val();
            //var multiplier = 1.108;

            var C47Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetC47").value;
            var C47Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayC47").value;

            var C45Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetC45").value;
            var C45Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayC45").value;

            var D169Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetD169").value;
            var D169Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayD169").value;

            //            var C52Budget = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetC52").value;
            //            var C52Today = document.getElementById("ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayC52").value;

            //            var txtBudgetBIPL = (C47Budget == '' ? 0 : parseInt(C47Budget)) + (C45Budget == '' ? 0 : parseInt(C45Budget)) + (D169Budget == '' ? 0 : parseInt(D169Budget)) + (C52Budget == '' ? 0 : parseInt(C52Budget));
            var txtBudgetBIPL = (C47Budget == '' ? 0 : parseInt(C47Budget)) + (C45Budget == '' ? 0 : parseInt(C45Budget)) + (D169Budget == '' ? 0 : parseInt(D169Budget));
            //            var txtTodayBIPL = (C47Today == '' ? 0 : parseInt(C47Today)) + (C45Today == '' ? 0 : parseInt(C45Today)) + (D169Today == '' ? 0 : parseInt(D169Today)) + (C52Today == '' ? 0 : parseInt(C52Today));
            var txtTodayBIPL = (C47Today == '' ? 0 : parseInt(C47Today)) + (C45Today == '' ? 0 : parseInt(C45Today)) + (D169Today == '' ? 0 : parseInt(D169Today));

            if (IsStatus == 'False') {
                var financialbudget = parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtManPowerBudget));
                //var financialbudget = isNaN(parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtManPowerBudget))) == false ? '' : (parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtManPowerBudget)));

                var BIPLbudget = 0;
                var BIPLToday = 0;

                if (gridIDLast == 'txtManPowerBudgetC47' || gridIDLast == 'txtManPowerBudgetC45' || gridIDLast == 'txtManPowerBudgetD169') {
                    BIPLbudget = parseFloat(Salary) * 1.1 * parseFloat(txtBudgetBIPL);
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtBudgetBIPL);
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_lbFinancialBudgetBIPL").text(Math.round(BIPLbudget).toString());
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").trigger('blur');
                }
                else if (gridIDLast == 'txtManPowerTodayC47' || gridIDLast == 'txtManPowerTodayC45' || gridIDLast == 'txtManPowerTodayD169') {
                    BIPLToday = parseFloat(Salary) * 1.1 * parseFloat(txtTodayBIPL);

                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtTodayBIPL);
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_lblFinancialTodayBIPL").text(Math.round(BIPLToday).toString());
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").trigger('blur');
                }

                if (isNaN(financialbudget)) {
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text('');
                }
                else {
                    if (financialbudget != 0) {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,'));
                    }
                    else {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text('');
                    }
                }
            }

            else {

                var financialbudget = (parseFloat(Salary) + ((parseFloat(Salary) / parseFloat(working_days) / parseFloat(working_hours)) * parseFloat(total_OT_Hours) * parseFloat(multiplier))) * parseFloat(txtManPowerBudget);

                var BIPLbudget = 0;
                var BIPLToday = 0;

                if (gridIDLast == 'txtManPowerBudgetC47' || gridIDLast == 'txtManPowerBudgetC45' || gridIDLast == 'txtManPowerBudgetD169') {
                    BIPLbudget = (parseFloat(Salary) + ((parseFloat(Salary) / parseFloat(working_days) / parseFloat(working_hours)) * parseFloat(total_OT_Hours) * parseFloat(multiplier))) * parseFloat(txtBudgetBIPL);
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtBudgetBIPL);
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_lbFinancialBudgetBIPL").text(Math.round(BIPLbudget).toString());
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").trigger('blur');
                }
                else if (gridIDLast == 'txtManPowerTodayC47' || gridIDLast == 'txtManPowerTodayC45' || gridIDLast == 'txtManPowerTodayD169') {
                    BIPLToday = (parseFloat(Salary) + ((parseFloat(Salary) / parseFloat(working_days) / parseFloat(working_hours)) * parseFloat(total_OT_Hours) * parseFloat(multiplier))) * parseFloat(txtTodayBIPL);
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtTodayBIPL);
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_lblFinancialTodayBIPL").text(Math.round(BIPLToday).toString());
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").trigger('blur');
                }

                if (isNaN(financialbudget)) {
                    $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text('');
                }
                else {
                    if (financialbudget != 0) {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,'));
                    }
                    else {
                        $("#ctl00_cph_main_content_grdMMReport_ctl" + ID + financialLable).text('');
                    }
                }
            }
        }

        //Disable Dates greater than Today's date
        //        $(function () {
        //            
        //                var todayDate = new Date();
        //                var year = todayDate.getFullYear();
        //                var month = todayDate.getMonth();
        //                var day = todayDate.getDate();
        //                //var maxDate = (year + "-" + month + "-" + day);
        //                
        //                $('.th3').datepicker({ maxDate: new Date(year, month, day)
        //                });            
        //        });

        //        function pageLoad() {
        //            var todayDate = new Date();
        //                            var year = todayDate.getFullYear();
        //                            var month = todayDate.getMonth();
        //                            var day = todayDate.getDate();
        //                            //var maxDate = (year + "-" + month + "-" + day);
        //                            
        //                            $('.th3').datepicker({ maxDate: new Date(year, month, day)
        //                            }); 
        //        }
        $(function () {

            //            $(".th3").datepicker({ dateFormat: 'dd M y (D)' });
            //            $(".th3").datepicker({ maxDate: 0 });
            //$(".th3").datepicker({ dateFormat: 'd M, y' });
            timedCount();
            $(".th3").datepicker({
                dateFormat: 'dd M y (D)',

                maxDate: 0
            });
        });


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

        function onlyNumbers(evt) {//FRO GRIDVIEW SALARY TEXBOX
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }


        function gridValidate() {

            var count1 = 0;
            var Count2 = 0;
            //        var count3 = 0;
            //        var Count4 = 0;
            //        var count5 = 0;
            //        var Count6 = 0;
            $('.WokertypeCss').each(function (index, item) {
                if ($(this).val() != "") {
                    count1 = 1;
                }
            }, 0);

            if (count1 == 0) {
                ShowHideMessageBox(true, "Enter worker type", "Manpower form");
                //alert("Enter Worker Type First .");
                return false;
            }

            $('.TxtWorkerTypeCss').each(function (index, item) {
                if ($(this).val() != "") {
                    Count2 = 1;
                }
            }, 0);

            if (Count2 == 0) {
                //alert("Enter salary First .");
                ShowHideMessageBox(true, "Enter salary", "Manpower form");
                return false;
            }

            else {
                return true;
            }
        }
        function pageLoad() {
            //  alert();
            //            $(".th3").datepicker({ dateFormat: 'dd M y (D)' });


            // $(".th3").datepicker({ maxDate: 0 });
            $(".th3").datepicker({
                dateFormat: 'dd M y (D)',

                maxDate: 0
            });
            $('.numericTwoDecimal').keypress(function (event) {
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
                    ((event.which < 48 || event.which > 57) &&
                      (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 2) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });

        }

        function timedCount() {
            var hours = parseInt(parseInt($('#RemainSec').val()) / 3600) % 24;
            var minutes = parseInt(parseInt($('#RemainSec').val()) / 60) % 60;
            var seconds = parseInt($('#RemainSec').val()) % 60;
            var result = (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes) + ":" + (seconds < 10 ? "0" + seconds : seconds);
            $('#timer').html(result);
            if (parseInt($('#RemainSec').val()) == 1) {
                window.location.reload();
            }
            $('#RemainSec').val(parseInt($('#RemainSec').val()) - 1);
            t = setTimeout(function () {
                timedCount();
            }, 1000);
        }
    </script>
    <link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
    <asp:Panel runat="server" ID="pnlMain" Visible="true" CssClass="do-not-include">
        <div id="ScroolTop">
            <%--  <form id="form1" runat="server">--%>
            <div>
                <table border="0" align="left" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdn_cmt_workingdays" runat="server" Value="0" />
                            <%--added by raghvinder 13-05-2020 start--%>
                            <asp:HiddenField ID="hdnworkingdays" runat="server" Value="0" />
                            <asp:HiddenField ID="hdnworkinghour" runat="server" Value="0" />
                            <asp:HiddenField ID="hdnOT" runat="server" Value="0" />
                            <asp:HiddenField ID="hdnTotalOTHours" runat="server" Value="0" />
                            <asp:HiddenField ID="hdnmultiplier" runat="server" Value="0" />
                            <%--added by raghvinder 13-05-2020 end--%>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper" bgcolor="#ffffff" style="padding: 0px 10px">
                                <tr>
                                    <td class="main-heading">
                                        Daily MMR Report Entry Admin
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="font-size: 12px; font-weight: normal; color: #3b5998; line-height: 30px; text-align: left; text-transform: none; width: 32%">
                                                    All <span style="color: Red; font-size: 12px;">*</span> (asterisk) mark field mandatory
                                                </td>
                                                <td style="font-size: 12px; font-weight: normal; color: #0088cc; line-height: 30px; text-align: left; text-transform: none; width: 36%">
                                                    (Factory man power details (department, salary, Ob/Non-OB, OT)
                                                </td>
                                                <td style="font-size: 12px; font-weight: normal; color: #0088cc; line-height: 30px; text-align: right; text-transform: none; width: 32%">
                                                    Time remaining to refresh (<span id="timer"> </span>)
                                                    <input type="hidden" id="RemainSec" value="1500" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--new code 10 july 2020 start--%>
                                        <asp:UpdateProgress runat="server" ID="updateMMR" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
                                            <ProgressTemplate>
                                                <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed; z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <%--new code 10 july 2020 end--%>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table width="60%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px; border: 1px solid #ccc;">
                                                    <tr class="td-sub_headings border">
                                                        <td class="heading-bg" width="80px">
                                                            <span style="font-size: 12px">Worker type</span>
                                                        </td>
                                                        <td width="90px">
                                                            <input style="text-transform: none; width: 96%;" maxlength="50" runat="server" title="Enter type of worker name" id="txtWorker" class="WokertypeCss" type="text" />
                                                        </td>
                                                        <td class="heading-bg" style="width: 40px">
                                                            <span style="font-size: 12px">Department</span>
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:DropDownList ID="DDl_Dept" ToolTip="Select worker department" runat="server" Width="90%" BackColor="#F6F1DB" ForeColor="#7d6754" Style="line-height: 20px !important;">
                                                                <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                <asp:ListItem Value="0">Accessory</asp:ListItem>
                                                                <asp:ListItem Value="1">Cutting</asp:ListItem>
                                                                <asp:ListItem Value="2">Fabric</asp:ListItem>
                                                                <asp:ListItem Value="3">Finishing</asp:ListItem>
                                                                <asp:ListItem Value="4">Misc</asp:ListItem>
                                                                <asp:ListItem Value="5">R&D</asp:ListItem>
                                                                <asp:ListItem Value="6">Stitching</asp:ListItem>
                                                                <asp:ListItem Value="7">XNY</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rvfDDl_Dept" runat="server" ErrorMessage="Invalid Selection!!" ForeColor="Red" Text="*" ControlToValidate="DDl_Dept" InitialValue="Select"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="heading-bg" style="width: 40px; font-size: 12px !important">
                                                            Date
                                                        </td>
                                                        <td style="width: 100px">
                                                            <input style="text-transform: none; width: 96%;" runat="server" id="txtCreatedDate" autocomplete="off" class="th3" type="text" />
                                                        </td>
                                                        <td style="border-left: none; text-align: center; width: 40px;">
                                                            <asp:Button ID="btnsubmit" Text="Search" CssClass="submit" runat="server" OnClick="btnsubmit_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <br />
                                                <table width="50%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdBudgetShortfall" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="13px" ShowHeader="false" ShowFooter="false" OnRowCreated="grdBudgetShortfall_RowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDepartment" Text='<%#Eval("WorkerType") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <%--<asp:Label ID="lblShortfall" Text='<%#Eval("shortfall")%>' runat="server"></asp:Label>--%>
                                                                            <asp:Label ID="lblShortfall" Text='<%# (int)Eval("shortfall")==0 ? "": Eval("shortfall") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtReasonForShortfall" Text='<%#Eval("ReasonForShortFall")%>' runat="server" Width="98%" Style="text-align: center"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="260px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtOnTrial" Text='<%#Eval("OnTrial")%>' runat="server" Style="text-align: center"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtHRremark" Text='<%#Eval("HRremarks")%>' runat="server" Style="text-align: center"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="130px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <label style="color: Red">
                                                                        NO RECORD FOUND</label></EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <div style="text-align: center; margin-top: 15px; margin-bottom: 10px">
                                                                <asp:Button ID="btnSaveShortfall" runat="server" Text="Save" CssClass="save da_submit_button" Visible="true" OnClick="btnSaveShortfall_Click" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="30%" style="margin-left: 5px; margin-top: 10px;" border="0" align="left" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td colspan="5" style="text-align: center; background-color: #39589C; color: #fff">
                                                            Outhouse Detail
                                                        </td>
                                                    </tr>
                                                    <tr class="td-sub_headings border">
                                                        <td class="" width="80px">
                                                            <span style="font-size: 12px">Pieces</span>
                                                        </td>
                                                        <td style="width: 90px; text-align: center">
                                                            <input style="text-transform: none; width: 90%;" maxlength="50" runat="server" title="Enter no of Pieces" id="txtPieces" class="WokertypeCss" type="text" onkeypress="return onlyNumbers(event);" />
                                                        </td>
                                                        <td class="" style="width: 40px">
                                                            <span style="font-size: 12px">Rate</span>
                                                        </td>
                                                        <td style="width: 90px; text-align: center">
                                                            <input style="text-transform: none; width: 90%;" maxlength="50" runat="server" title="Enter Rate per piece" id="txtRate" class="WokertypeCss numericTwoDecimal" type="text" />
                                                        </td>
                                                        <td style="text-align: center; width: 60px;">
                                                            <div style="text-align: center;">
                                                                <asp:Button ID="btnSaveCmtAdminRateAndPieces" runat="server" ForeColor="white" Text="Save" CssClass="save da_submit_button" Visible="true" OnClick="btnSaveCmtAdminRateAndPieces_Click" />
                                                            </div>
                                                        </td>
                                                </table>
                                                <table width="10%" style="margin-left: 5px; margin-top: 10px;" border="0" align="left" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td colspan="5" style="text-align: center; background-color: #39589C; color: #fff">
                                                            Working Days
                                                        </td>
                                                    </tr>
                                                    <tr class="td-sub_headings border">
                                                        <%--<td class="" width="80px">
                                                        <span style="font-size: 12px">Days</span>
                                                    </td>--%>
                                                        <td style="width: 90px; text-align: center">
                                                            <input style="text-transform: none; width: 90%;" maxlength="50" runat="server" title="Enter no of Days" id="txtOTDays" class="WokertypeCss" type="text" onkeypress="return onlyNumbers(event);" />
                                                        </td>
                                                        <td style="text-align: center; width: 60px;">
                                                            <div style="text-align: center;">
                                                                <asp:Button ID="btnSaveOTDays" runat="server" ForeColor="white" Text="Save" CssClass="save da_submit_button" Visible="true" OnClick="btnSaveOTDays_Click" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <td style="padding-bottom: 10px;">
                                                                <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;"></span>
                                                            </td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:GridView ID="grdMMReport" runat="server" OnRowDataBound="grdMMReport_RowDataBound" AutoGenerateColumns="False" Width="100%" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="13px" OnRowCreated="grdMMReport_RowCreated" ShowHeader="False">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList AutoPostBack="true" ID="ddl_Depart" runat="server" Style="width: 90%; color: gray">
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="100PX">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtWorkerType" Style="text-transform: capitalize; width: 97%; color: #000;" runat="server" CssClass="WokertypeCss" onkeypress="return onlyNumbers(event);" Text='<%#Eval("WorkerType")%>'></asp:TextBox>
                                                                                <asp:HiddenField ID="hdnworkerType" runat="server" Value='<%#Eval("FactoryWorkSpace")%>' />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="200px" CssClass="minWithFis" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="OB based" HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lbl_obsed" ForeColor="gray" Text='<%#Eval("OBbased") %>'></asp:Label>
                                                                            <asp:HiddenField ID="hdn_Part_Of_MMR" runat="server" Value='<%#Eval("OBbased") %>' />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" />
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lbl_Salary" ForeColor="gray" Text='<%#Eval("Salary") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" />
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lbl_Status" ForeColor="gray" Text='<%#Eval("IsStatus") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Font-Bold="False" />
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtManPowerBudgetC47" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("C47_Budget")%>' runat="server" onblur="CalculateFinancials(this)" ReadOnly="true"></asp:TextBox>
                                                                            <asp:HiddenField ID="hdnSalary" runat="server" Value='<%#Eval("Salary")%>' />
                                                                            <asp:HiddenField ID="hdnIsStatus" runat="server" Value='<%#Eval("IsStatus")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtManPowerTodayC47" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("C47_Today")%>' runat="server" onblur="CalculateFinancials(this)"></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="TodayBackColorYellow" Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lbFinancialBudgetC47" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lblFinancialTodayC47" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="tadayBackColor" Width="80px" />
                                                                        <HeaderStyle Font-Bold="False" Width="50px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtManPowerBudgetC45" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("C4546_Budget")%>' runat="server" onblur="CalculateFinancials(this)" ReadOnly="true"></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtManPowerTodayC45" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("C4546_Today")%>' runat="server" onblur="CalculateFinancials(this)"></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="TodayBackColorYellow" Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lbFinancialBudgetC45" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lblFinancialTodayC45" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="tadayBackColor" Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtManPowerBudgetD169" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("D169_Budget")%>' runat="server" onblur="CalculateFinancials(this)" ReadOnly="true"></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtManPowerTodayD169" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("D169_Today")%>' runat="server" onblur="CalculateFinancials(this)"></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="TodayBackColorYellow" Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lbFinancialBudgetD169" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lblFinancialTodayD169" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="tadayBackColor" Width="80px" />
                                                                        <HeaderStyle Font-Bold="False" />
                                                                    </asp:TemplateField>
                                                                    <%--added by raghvinder on 02-11-2020 start--%>
                                                                    <%-- <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                    <ItemTemplate>
                                                                        <div style="text-transform: capitalize;">
                                                                            <asp:TextBox ID="txtManPowerBudgetC52" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                                onpaste="return false;" Width="40px" Text='<%#Eval("C52_Budget")%>' runat="server"
                                                                                onblur="CalculateFinancials(this)" ReadOnly="true"></asp:TextBox>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="80px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                    <ItemTemplate>
                                                                        <div style="text-transform: capitalize;">
                                                                            <asp:TextBox ID="txtManPowerTodayC52" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                                onpaste="return false;" Width="40px" Text='<%#Eval("C52_Today")%>' runat="server"
                                                                                onblur="CalculateFinancials(this)"></asp:TextBox>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="TodayBackColorYellow" Width="80px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                    <ItemTemplate>
                                                                        <div style="text-transform: capitalize;">
                                                                            <asp:Label ID="lbFinancialBudgetC52" Text='' runat="server"></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="80px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                    <ItemTemplate>
                                                                        <div style="text-transform: capitalize;">
                                                                            <asp:Label ID="lblFinancialTodayC52" Text='' runat="server"></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="tadayBackColor" Width="80px" />
                                                                    <HeaderStyle Font-Bold="False" />
                                                                </asp:TemplateField>--%>
                                                                    <%--added by raghvinder on 02-11-2020 end--%>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtManPowerBudgetBIPL" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("Bipl_Budget")%>' runat="server" onblur="CalculateFinancialBIPL(this)" ReadOnly="true"></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:TextBox ID="txtManPowerTodayBIPL" MaxLength="10" onkeypress="return onlyNumbers(event);" onpaste="return false;" Width="40px" Text='<%#Eval("Bipl_Today")%>' runat="server" onblur="CalculateFinancialBIPL(this)"></asp:TextBox>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="TodayBackColorYellow" Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lbFinancialBudgetBIPL" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                        <ItemTemplate>
                                                                            <div style="text-transform: capitalize;">
                                                                                <asp:Label ID="lblFinancialTodayBIPL" Text='' runat="server"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="tadayBackColor" />
                                                                        <HeaderStyle Font-Bold="False" Width="50px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <label style="color: Red">
                                                                        NO RECORD FOUND</label></EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div style="text-align: center; margin-top: 30px; margin-bottom: 10px">
                                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="save da_submit_button" Visible="true" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <%--   </form>--%>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlMessage" Visible="false" CssClass="do-not-include">
        <div class="form_box">
            <div class="form_heading" style="color: #fff">
                Access Denied
            </div>
            <div class="text-content" style="text-transform: initial">
                Someone else is using MMR entry, When it finished then only you can access!
            </div>
        </div>
    </asp:Panel>
</asp:Content>
