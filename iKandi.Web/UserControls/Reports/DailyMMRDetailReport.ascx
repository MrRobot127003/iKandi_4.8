<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyMMRDetailReport.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.DailyMMRDetailReport" %>

    <style type="text/css">
        
        .header1 td
        {
            background-color: #e6e6e6;
            color: #575759 !important;
            font-size: 11px;
            border: 1px solid #999;
        }
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
        
        .select-con
        {
            font-size: 12px;
            line-height: 20px !important;
        }
        .select-con option
        {
            background: #fff;
            font-size: 14px !important;
            font-family: verdana;
            color: #000;
            line-height: 20px !important;
            padding-bottom: 5px;
        }
        #main_content
        {
            text-transform: capitalize !important;
        }
        /*-------------------------9-nov-2015------------------------- */
        .main_tbl_wrapper
        {
            background: #ffffff;
        }
        
        
        .border td
        {
            font-size: 10px !important;
        }
        .heading-bg
        {
            padding: 10px 3px !important;
        }
        .border2 th
        {
            padding: 2px !important;
        }
        .font
        {
            font-size: 12px !important;
        }
        #secure_banner_cor
        {
            background: none !important;
        }
        #grdMMReport td
        {
            text-align: center;
            width: 60px;
        }
        #grdMMReport td input[type='text']
        {
            text-align: center;
            color: blue;
            width: 94% !important;
        }
        .tadayBackColor
        {
            background: #DCE6F1;
        }
        .TodayBackColorYellow
        {
            background: yellow;
        }
    </style>
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


        //added by raghvinder on 18-05-2020 starts
        function CalculateFinancialBIPL(elem) {
            debugger;
            //var txtBIPLValue = elem.value;
            var txtManPowerBudget = elem.value;

            var objId = elem.id.split("_")[1].substr(3);
            var gridID = elem.id.split("_")[0];
            var gridIDLast = elem.id.split("_")[2];

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

            else if (gridIDLast == 'txtManPowerBudgetBIPL') {
                financialLable = '_lbFinancialBudgetBIPL';
            }

            else if (gridIDLast == 'txtManPowerTodayBIPL') {
                financialLable = '_lblFinancialTodayBIPL';
            }

            var gridIDFull = "'" + '#' + elem.id + "'";

            var ID = elem.id.split("_")[1].substr(3);

            var Salary = document.getElementById("grdMMReport_ctl" + ID + "_hdnSalary").value;
            var IsStatus = document.getElementById("grdMMReport_ctl" + ID + "_hdnIsStatus").value;
            var total_OT_Hours = document.getElementById("hdnTotalOTHours").value;
            var working_days = document.getElementById("hdnworkingdays").value;
            var OT = document.getElementById("hdnOT").value;
            var working_hours = document.getElementById("hdnworkinghour").value;
            var multiplier = document.getElementById("hdnmultiplier").value;

            var C47Budget = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerBudgetC47").value;
            var C47Today = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerTodayC47").value;

            var C45Budget = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerBudgetC45").value;
            var C45Today = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerTodayC45").value;

            var D169Budget = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerBudgetD169").value;
            var D169Today = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerTodayD169").value;

            var txtBIPLSum = 0;
            if (gridIDLast == 'txtManPowerBudgetBIPL') {
                txtBIPLSum = (C47Budget == '' ? 0 : parseInt(C47Budget)) + (C45Budget == '' ? 0 : parseInt(C45Budget)) + (D169Budget == '' ? 0 : parseInt(D169Budget));
            }
            if (gridIDLast == 'txtManPowerTodayBIPL') {
                txtBIPLSum = (C47Today == '' ? 0 : parseInt(C47Today)) + (C45Today == '' ? 0 : parseInt(C45Today)) + (D169Today == '' ? 0 : parseInt(D169Today));
            }

            if (IsStatus == 'False') {
                var financialbudget
                if (parseInt(txtManPowerBudget) > txtBIPLSum) {
                    financialbudget = parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtManPowerBudget));
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {

                        $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtManPowerBudget);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtManPowerBudget);
                    }
                }
                else {
                    financialbudget = parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtBIPLSum));
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {
                        $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtBIPLSum);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtBIPLSum);
                    }
                }

                if (financialbudget != 0) {
                    $("#grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString());

                }
                else {
                    $("#grdMMReport_ctl" + ID + financialLable).text('');
                }
            }
            else {
                debugger;
                var financialbudget
                if (parseInt(txtManPowerBudget) > txtBIPLSum) {
                    financialbudget = (parseFloat(Salary) + ((parseFloat(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * parseFloat(txtManPowerBudget);
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {
                        $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtManPowerBudget);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtManPowerBudget);
                    }
                }
                else {
                    financialbudget = (parseFloat(Salary) + ((parseFloat(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * parseFloat(txtBIPLSum);
                    if (gridIDLast == 'txtManPowerBudgetBIPL') {
                        $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtBIPLSum);
                    }
                    else if (gridIDLast == 'txtManPowerTodayBIPL') {
                        $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtBIPLSum);
                    }
                }

                if (financialbudget != 0) {
                    $("#grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString());
                }
                else {
                    $("#grdMMReport_ctl" + ID + financialLable).text('');
                }
            }
        }

        function CalculateFinancials(elem) {
            debugger;
            var financialLable = '';
            var txtManPowerBudget = elem.value;

            var objId = elem.id.split("_")[1].substr(3);
            var gridID = elem.id.split("_")[0];
            var gridIDLast = elem.id.split("_")[2];

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

            else if (gridIDLast == 'txtManPowerBudgetBIPL') {
                financialLable = '_lbFinancialBudgetBIPL';
            }

            else if (gridIDLast == 'txtManPowerTodayBIPL') {
                financialLable = '_lblFinancialTodayBIPL';
            }

            var gridIDFull = "'" + '#' + elem.id + "'";

            var ID = elem.id.split("_")[1].substr(3);

            var Salary = document.getElementById("grdMMReport_ctl" + ID + "_hdnSalary").value;
            var IsStatus = document.getElementById("grdMMReport_ctl" + ID + "_hdnIsStatus").value;
            var total_OT_Hours = document.getElementById("hdnTotalOTHours").value;
            var working_days = document.getElementById("hdnworkingdays").value;
            var OT = document.getElementById("hdnOT").value;
            var working_hours = document.getElementById("hdnworkinghour").value;
            var multiplier = document.getElementById("hdnmultiplier").value;

            var C47Budget = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerBudgetC47").value;
            var C47Today = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerTodayC47").value;

            var C45Budget = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerBudgetC45").value;
            var C45Today = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerTodayC45").value;

            var D169Budget = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerBudgetD169").value;
            var D169Today = document.getElementById("grdMMReport_ctl" + ID + "_txtManPowerTodayD169").value;

            var txtBudgetBIPL = (C47Budget == '' ? 0 : parseInt(C47Budget)) + (C45Budget == '' ? 0 : parseInt(C45Budget)) + (D169Budget == '' ? 0 : parseInt(D169Budget));
            var txtTodayBIPL = (C47Today == '' ? 0 : parseInt(C47Today)) + (C45Today == '' ? 0 : parseInt(C45Today)) + (D169Today == '' ? 0 : parseInt(D169Today));

            if (IsStatus == 'False') {
                var financialbudget = parseFloat(Salary) * 1.1 * (txtManPowerBudget == '' ? 0 : parseFloat(txtManPowerBudget));

                var BIPLbudget = 0;
                var BIPLToday = 0;

                if (gridIDLast == 'txtManPowerBudgetC47' || gridIDLast == 'txtManPowerBudgetC45' || gridIDLast == 'txtManPowerBudgetD169') {
                    BIPLbudget = parseFloat(Salary) * 1.1 * parseFloat(txtBudgetBIPL);
                    $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtBudgetBIPL);
                    $("#grdMMReport_ctl" + ID + "_lbFinancialBudgetBIPL").text(Math.round(BIPLbudget).toString());
                    $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").trigger('change');
                }
                else if (gridIDLast == 'txtManPowerTodayC47' || gridIDLast == 'txtManPowerTodayC45' || gridIDLast == 'txtManPowerTodayD169') {
                    BIPLToday = parseFloat(Salary) * 1.1 * parseFloat(txtTodayBIPL);
                    $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtTodayBIPL);
                    $("#grdMMReport_ctl" + ID + "_lblFinancialTodayBIPL").text(Math.round(BIPLToday).toString());
                    $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").trigger('change');
                }


                if (financialbudget != 0) {
                    $("#grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString());

                }
                else {
                    $("#grdMMReport_ctl" + ID + financialLable).text('');
                }
            }
            else {

                var financialbudget = (parseFloat(Salary) + ((parseFloat(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * parseFloat(txtManPowerBudget);

                var BIPLbudget = 0;
                var BIPLToday = 0;

                if (gridIDLast == 'txtManPowerBudgetC47' || gridIDLast == 'txtManPowerBudgetC45' || gridIDLast == 'txtManPowerBudgetD169') {
                    BIPLbudget = (parseFloat(Salary) + ((parseFloat(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * parseFloat(txtBudgetBIPL);
                    $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").val(txtBudgetBIPL);
                    $("#grdMMReport_ctl" + ID + "_lbFinancialBudgetBIPL").text(Math.round(BIPLbudget).toString());
                    $("#grdMMReport_ctl" + ID + "_txtManPowerBudgetBIPL").trigger('change');
                }
                else if (gridIDLast == 'txtManPowerTodayC47' || gridIDLast == 'txtManPowerTodayC45' || gridIDLast == 'txtManPowerTodayD169') {
                    BIPLToday = (parseFloat(Salary) + ((parseFloat(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * parseFloat(txtTodayBIPL);
                    $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").val(txtTodayBIPL);
                    $("#grdMMReport_ctl" + ID + "_lblFinancialTodayBIPL").text(Math.round(BIPLToday).toString());
                    $("#grdMMReport_ctl" + ID + "_txtManPowerTodayBIPL").trigger('change');
                }

                if (financialbudget != 0) {
                    $("#grdMMReport_ctl" + ID + financialLable).text(Math.round(financialbudget).toString());
                }
                else {
                    $("#grdMMReport_ctl" + ID + financialLable).text('');
                }
            }



        }
        $(function () {
            $(".th3").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        function pageLoad() {
            $(".th3").datepicker({ dateFormat: 'yy-mm-dd' });
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
    </script>
    <link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" /> 


<div>
    <table width="1600PX" border="0" align="left" cellpadding="0" cellspacing="0">
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
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
                    bgcolor="#ffffff" style="padding: 0px 10px">
                    <tr>
                        <td class="main-heading">
                            Factory Work Force Admin
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="font-size: 12px; font-weight: normal; color: #3b5998; line-height: 30px;
                                        text-align: left; text-transform: none; width: 32%">
                                        All <span style="color: Red; font-size: 12px;">*</span> (asterisk) mark field mandatory
                                    </td>
                                    <td style="font-size: 12px; font-weight: normal; color: #0088cc; line-height: 30px;
                                        text-align: left; text-transform: none; width: 68%">
                                        (Factory man power details (department, salary, Ob/Non-OB, OT)
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table width="90%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px;
                                        border: 1px solid #ccc;">
                                        <tr class="td-sub_headings border">
                                            <td class="heading-bg" width="30px">
                                                Worker type
                                            </td>
                                            <td width="90px">
                                                <input style="text-transform: none; width: 80%;" maxlength="50" runat="server" title="Enter type of worker name"
                                                    id="txtWorker" class="WokertypeCss" type="text" />
                                            </td>
                                            <td class="heading-bg" style="width: 30px">
                                                Department
                                            </td>
                                            <td width="60px">
                                                <asp:DropDownList ID="DDl_Dept" ToolTip="Select worker department" runat="server"
                                                    Width="90%" BackColor="#F6F1DB" AutoPostBack="true" ForeColor="#7d6754" Style="line-height: 20px !important;">
                                                    <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                    <asp:ListItem Value="0">Stitching</asp:ListItem>
                                                    <asp:ListItem Value="1">Finishing</asp:ListItem>
                                                    <asp:ListItem Value="2">Cutting</asp:ListItem>
                                                    <asp:ListItem Value="3">Misc</asp:ListItem>
                                                    <asp:ListItem Value="4">XNY</asp:ListItem>
                                                    <asp:ListItem Value="5">Accessory</asp:ListItem>
                                                    <asp:ListItem Value="6">R&D</asp:ListItem>
                                                    <asp:ListItem Value="7">Fabric</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rvfDDl_Dept" runat="server" ErrorMessage="Invalid Selection!!"
                                                    ForeColor="Red" Text="*" ControlToValidate="DDl_Dept" InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="heading-bg" style="width: 60px">
                                                <input style="text-transform: none; width: 80%;" runat="server" id="txtCreatedDate"
                                                    autocomplete="off" class="th3" type="text" />
                                            </td>
                                            <td align="left" width="60px" style="border-left: none;">
                                                <asp:Button ID="btnsubmit" Text="Search" CssClass="submit" runat="server" OnClick="btnsubmit_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <table width="50%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;">
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdBudgetShortfall" runat="server" AutoGenerateColumns="false"
                                                    HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="13px"
                                                    ShowHeader="false" ShowFooter="false" OnRowCreated="grdBudgetShortfall_RowCreated">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDepartment" Text='<%#Eval("WorkerType") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblShortfall" Text='<%#Eval("shortfall")%>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtReasonForShortfall" Text='<%#Eval("ReasonForShortFall")%>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtOnTrial" Text='<%#Eval("OnTrial")%>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtHRremark" Text='<%#Eval("HRremarks")%>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <label style="color: Red">
                                                            NO RECORD FOUND</label></EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="text-align: left">
                                                <div style="text-align: center; margin-top: 15px; margin-bottom: 10px">
                                                    <asp:Button ID="btnSaveShortfall" runat="server" Text="Save" CssClass="save da_submit_button"
                                                        Visible="true" OnClick="btnSaveShortfall_Click" />
                                                </div>
                                            </td>
                                        </tr>--%>
                                    </table>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <td style="padding-bottom: 10px;">
                                                    <span class="da_h1" style="font-size: 20px; text-align: left; color: Black; font-family: Lucida Sans Unicode;">
                                                    </span>
                                                </td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:GridView ID="grdMMReport" runat="server" OnRowDataBound="grdMMReport_RowDataBound"
                                                    AutoGenerateColumns="False" Width="90%" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Font-Size="13px" OnRowCreated="grdMMReport_RowCreated" ShowHeader="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                            <ItemTemplate>
                                                                <asp:DropDownList AutoPostBack="true" ID="ddl_Depart" runat="server" Style="width: 90%">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="100PX">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtWorkerType" Style="text-transform: capitalize; width: 97%; color: #000;"
                                                                        runat="server" CssClass="WokertypeCss" onkeypress="return onlyNumbers(event);"
                                                                        Text='<%#Eval("WorkerType")%>'></asp:TextBox>
                                                                    <asp:HiddenField ID="hdnworkerType" runat="server" Value='<%#Eval("FactoryWorkSpace")%>' />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OB based" HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lbl_obsed" Text='<%#Eval("OBbased") %>'></asp:Label>
                                                                <asp:HiddenField ID="hdn_Part_Of_MMR" runat="server" Value='<%#Eval("OBbased") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lbl_Salary" Text='<%#Eval("Salary") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lbl_Status" Text='<%#Eval("IsStatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtManPowerBudgetC47" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                    onpaste="return false;" Width="40px" Text='<%#Eval("C47_Budget")%>' runat="server"
                                                                    onchange="CalculateFinancials(this)"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnSalary" runat="server" Value='<%#Eval("Salary")%>' />
                                                                <asp:HiddenField ID="hdnIsStatus" runat="server" Value='<%#Eval("IsStatus")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtManPowerTodayC47" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                        onpaste="return false;" Width="40px" Text='<%#Eval("C47_Today")%>' runat="server"
                                                                        onchange="CalculateFinancials(this)"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="TodayBackColorYellow" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:Label ID="lbFinancialBudgetC47" Text='' runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:Label ID="lblFinancialTodayC47" Text='' runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="tadayBackColor" />
                                                            <HeaderStyle Font-Bold="False" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtManPowerBudgetC45" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                        onpaste="return false;" Width="40px" Text='<%#Eval("C4546_Budget")%>' runat="server"
                                                                        onchange="CalculateFinancials(this)"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtManPowerTodayC45" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                        onpaste="return false;" Width="40px" Text='<%#Eval("C4546_Today")%>' runat="server"
                                                                        onchange="CalculateFinancials(this)"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="TodayBackColorYellow" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:Label ID="lbFinancialBudgetC45" Text='' runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:Label ID="lblFinancialTodayC45" Text='' runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="tadayBackColor" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtManPowerBudgetD169" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                        onpaste="return false;" Width="40px" Text='<%#Eval("D169_Budget")%>' runat="server"
                                                                        onchange="CalculateFinancials(this)"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtManPowerTodayD169" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                        onpaste="return false;" Width="40px" Text='<%#Eval("D169_Today")%>' runat="server"
                                                                        onchange="CalculateFinancials(this)"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="TodayBackColorYellow" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:Label ID="lbFinancialBudgetD169" Text='' runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:Label ID="lblFinancialTodayD169" Text='' runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="tadayBackColor" />
                                                            <HeaderStyle Font-Bold="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtManPowerBudgetBIPL" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                        onpaste="return false;" Width="40px" Text='<%#Eval("Bipl_Budget")%>' runat="server"
                                                                        onchange="CalculateFinancialBIPL(this)"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:TextBox ID="txtManPowerTodayBIPL" MaxLength="10" onkeypress="return onlyNumbers(event);"
                                                                        onpaste="return false;" Width="40px" Text='<%#Eval("Bipl_Today")%>' runat="server"
                                                                        onchange="CalculateFinancialBIPL(this)"></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="TodayBackColorYellow" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                            <ItemTemplate>
                                                                <div style="text-transform: capitalize;">
                                                                    <asp:Label ID="lbFinancialBudgetBIPL" Text='' runat="server"></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
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
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="save da_submit_button"
                                            Visible="true" />
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
