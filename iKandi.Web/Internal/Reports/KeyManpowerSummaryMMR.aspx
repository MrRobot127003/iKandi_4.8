<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeyManpowerSummaryMMR.aspx.cs" Inherits="iKandi.Web.Internal.Reports.KeyManpowerSummaryMMR" %>

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
            // $(".th3").datepicker({ dateFormat: 'yy-mm-dd' });
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
                                    <asp:UpdateProgress runat="server" ID="updateKeymanpowerMMR" AssociatedUpdatePanelID="UpdatePanel1"
                                        DisplayAfter="0">
                                        <ProgressTemplate>
                                            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                                                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <%--new code 10 july 2020 end--%>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table width="25%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px;
                                            border: 1px solid #ccc;">
                                            <tr class="td-sub_headings border">
                                                   <td class="heading-bg" style="width: 60px;font-size:12px !important;">Date</td>
                                                <td style="width: 100px">
                                                    <input style="text-transform: none; width: 95%;" runat="server" id="txtCreatedDate" autocomplete="off"
                                                        class="th3" type="text" />
                                                </td>
                                                <td style="border-left: none; text-align:center;width:40px;">
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
                                                    <asp:GridView ID="grdKeyManPowerMMReport" runat="server" 
                                                        AutoGenerateColumns="False" Width="90%" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Font-Size="13px" ShowHeader="False"
                                                        ShowFooter="false" onrowcreated="grdKeyManPowerMMReport_RowCreated" 
                                                        onrowdatabound="grdKeyManPowerMMReport_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                <ItemTemplate>                                                                    
                                                                    <asp:Label ID="lblDepartment" Text='<%#Eval("WorkerType")%>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="100px" />
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>                                                                    
                                                                        <asp:Label ID="lblManPowerBudgetC47" Text='<%#Eval("C47_Budget")%>' runat="server"></asp:Label>
                                                                        <%--<asp:Label ID="lblManPowerBudgetC47" Text='<%# (int)Eval("C47_Budget")==0 ? "": Eval("C47_Budget") %>' runat="server"></asp:Label>--%>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerTodayC47" Text='<%#Eval("C47_Today")%>' runat="server"></asp:Label>
                                                                            <%--<asp:Label ID="lblManPowerTodayC47" Text='<%# (int)Eval("C47_Today")==0 ? "": Eval("C47_Today") %>' runat="server"></asp:Label>--%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />                                                               
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerC47Percent" runat="server"></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />                                                               
                                                                
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerBudgetC45" Text='<%#Eval("C4546_Budget")%>' runat="server"></asp:Label>
                                                                            <%--<asp:Label ID="lblManPowerBudgetC45" Text='<%# (int)Eval("C4546_Budget")==0 ? "": Eval("C4546_Budget") %>' runat="server"></asp:Label>--%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerTodayC45" Text='<%#Eval("C4546_Today")%>' runat="server"></asp:Label>
                                                                            <%--<asp:Label ID="lblManPowerTodayC45" Text='<%# (int)Eval("C4546_Today")==0 ? "": Eval("C4546_Today") %>' runat="server"></asp:Label>--%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center"  /> 
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerC45Percent"  runat="server"></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"  />                                                               
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                        
                                                                            <asp:Label ID="lblManPowerBudgetD169" Text='<%#Eval("D169_Budget")%>' runat="server"></asp:Label>
                                                                            <%--<asp:Label ID="lblManPowerBudgetD169" Text='<%# (int)Eval("D169_Budget")==0 ? "": Eval("D169_Budget") %>' runat="server"></asp:Label>--%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"  /> 
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">
                                                                
                                                                            <asp:Label ID="lblManPowerTodayD169" Text='<%#Eval("D169_Today")%>' runat="server"></asp:Label>
                                                                            <%--<asp:Label ID="lblManPowerTodayD169" Text='<%# (int)Eval("D169_Today")==0 ? "": Eval("D169_Today") %>' runat="server"></asp:Label>--%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center"  /> 
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerD169Percent"  runat="server"></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"  />                                     
                                                                
                                                            </asp:TemplateField>
                                                            
                                                            <%--added by raghvinder on 02-11-2020 start--%>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                        
                                                                            <asp:Label ID="lblManPowerBudgetC52" Text='<%#Eval("C52_Budget")%>' runat="server"></asp:Label>                                                                            
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"  /> 
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerTodayC52" Text='<%#Eval("C52_Today")%>' runat="server"></asp:Label>                                                                            
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center"  /> 
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">    
                                                                            <asp:Label ID="lblManPowerC52Percent"  runat="server"></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"  />                                     
                                                                
                                                            </asp:TemplateField>
                                                            <%--added by raghvinder on 02-11-2020 end--%>

                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                       
                                                                            <asp:Label ID="lblManPowerBudgetBIPL" Text='<%#Eval("BIPL_Budget")%>' runat="server"></asp:Label>
                                                                            <%--<asp:Label ID="lblManPowerBudgetBIPL" Text='<%# (int)Eval("BIPL_Budget")==0 ? "": Eval("BIPL_Budget") %>' runat="server"></asp:Label>--%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"  /> 
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                        
                                                                            <asp:Label ID="lblManPowerTodayBIPL" Text='<%#Eval("BIPL_Today")%>' runat="server"></asp:Label>
                                                                            <%--<asp:Label ID="lblManPowerTodayBIPL" Text='<%# (int)Eval("BIPL_Today")==0 ? "": Eval("BIPL_Today") %>' runat="server"></asp:Label>--%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center"  /> 
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false">
                                                                <ItemTemplate>
                                                                    <div style="text-transform: capitalize;">                                                                
                                                                            <asp:Label ID="lblManPowerBIPLPercent" runat="server"></asp:Label>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"  />                                     
                                                                
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
