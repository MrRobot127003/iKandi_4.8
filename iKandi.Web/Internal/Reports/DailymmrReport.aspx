<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailymmrReport.aspx.cs"
    Inherits="iKandi.Web.Internal.Reports.DailymmrReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .submit
        {
            cursor:pointer;
        }
    </style>
    <script src="../../js/Calender_new.js" type="text/javascript"></script>
    <script src="../../js/Calender_new2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //$(".th3").datepicker({ dateFormat: 'yy-mm-dd' });
            $(".th3").datepicker({
                dateFormat: 'dd M y (D)',

                maxDate: 0
            });
        });
        function pageLoad() {
            //$(".th3").datepicker({ dateFormat: 'yy-mm-dd' });
            $(".th3").datepicker({
                dateFormat: 'dd M y (D)',

                maxDate: 0
            });
        }
       
    </script>
    <link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="1600PX" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td>
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
                            <%--new code 10 july 2020 start--%>
                                    <asp:UpdateProgress runat="server" ID="updateMMR" AssociatedUpdatePanelID="UpdatePanel1"
                                        DisplayAfter="0">
                                        <ProgressTemplate>
                                            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                                                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <%--new code 10 july 2020 end--%>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table width="20%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px;
                                            border: 1px solid #ccc;">
                                            <tr class="td-sub_headings border">
                                                <td class="heading-bg" style="width: 40px; font-size: 12px !important">
                                                    Date
                                                </td>
                                                <td style="width: 100px">
                                                    <input style="text-transform: none; width: 96%;" runat="server" id="txtCreatedDate"
                                                        autocomplete="off" class="th3" type="text" />
                                                </td>
                                                <td align="left" width="60px" style="border-left: none; text-align: center">
                                                    <asp:Button ID="btnsubmit" Text="Search" CssClass="submit" runat="server" OnClick="btnsubmit_Click" />
                                                </td>
                                            </tr>
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
        AutoGenerateColumns="False" Width="1400px" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
        HeaderStyle-Font-Size="12px" OnRowCreated="grdMMReport_RowCreated" ShowHeader="False"
        ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                <ItemTemplate>
                    <asp:Label ID="lblDepartment" Text='<%#Eval("Department")%>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="200px" CssClass="FirstColor" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lbltotal" runat="server" Text="BIPL Production Totals (incl. OT)"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="FirstColor" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <asp:Label ID="lblManPowerBudgetC47" Text='<%#Eval("C47ManPowerBudget")%>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerBudgetC47Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerTodayC47" Text='<%#Eval("C47ManPowerToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerTodayC47Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="TodayBackColorYellow" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lbFinancialBudgetC47" Text='<%#Eval("C47FinancialBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblFinancialBudgetC47Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblFinancialTodayC47" Text='<%#Eval("C47FinancialToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="tadayBackColor" HorizontalAlign="Center" />
                <HeaderStyle Font-Bold="False" Width="50px" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblFinancialTodayC47Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="tadayBackColor" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50px">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerBudgetC45" Text='<%#Eval("C45ManPowerBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerBudgetC45Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerTodayC45" Text='<%#Eval("C45ManPowerToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerTodayC45Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="TodayBackColorYellow" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lbFinancialBudgetC45" Text='<%#Eval("C45FinancialBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lbFinancialBudgetC45Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblFinancialTodayC45" Text='<%#Eval("C45FinancialToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="tadayBackColor" HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblFinancialTodayC45Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="tadayBackColor" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerBudgetD169" Text='<%#Eval("D169ManPowerBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerBudgetD169Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerTodayD169" Text='<%#Eval("D169ManPowerToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerTodayD169Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="TodayBackColorYellow" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lbFinancialBudgetD169" Text='<%#Eval("D169FinancialBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lbFinancialBudgetD169Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblFinancialTodayD169" Text='<%#Eval("D169FinancialToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="tadayBackColor" HorizontalAlign="Center" />
                <HeaderStyle Font-Bold="False" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblFinancialTodayD169Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="tadayBackColor" />
            </asp:TemplateField>
            <%--added by raghvinder on 02-11-2020 start--%>
            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerBudgetC52" Text='<%#Eval("C52ManPowerBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerBudgetC52Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerTodayC52" Text='<%#Eval("C52ManPowerToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerTodayC52Total" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="TodayBackColorYellow" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lbFinancialBudgetC52" Text='<%#Eval("C52FinancialBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lbFinancialBudgetC52Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblFinancialTodayC52" Text='<%#Eval("C52FinancialToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="tadayBackColor" HorizontalAlign="Center" />
                <HeaderStyle Font-Bold="False" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblFinancialTodayC52Total" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="tadayBackColor"/>
            </asp:TemplateField>
            <%--added by raghvinder on 02-11-2020 end--%>
            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerBudgetBIPL" Text='<%#Eval("BIPLManPowerBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerBudgetBIPLTotal" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerTodayBIPL" Text='<%#Eval("BIPLManPowerToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblManPowerTodayBIPLTotal" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="TodayBackColorYellow" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lbFinancialBudgetBIPL" Text='<%#Eval("BIPLFinancialBudget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lbFinancialBudgetBIPLTotal" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblFinancialTodayBIPL" Text='<%#Eval("BIPLFinancialToday")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="tadayBackColor" HorizontalAlign="Center" />
                <HeaderStyle Font-Bold="False" Width="50px" />
                <FooterTemplate>
                    <b>
                        <asp:Label ID="lblFinancialTodayBIPLTotal" ForeColor="blue" Font-Size="15px" runat="server"></asp:Label></b>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Center" CssClass="tadayBackColor" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="text-align: center; margin-top: 30px; margin-bottom: 10px">
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
    </form>
</body>
</html>
