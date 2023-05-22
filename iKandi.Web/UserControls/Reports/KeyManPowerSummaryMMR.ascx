<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeyManPowerSummaryMMR.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.KeyManPowerSummaryMMR" %>
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
    .TodayBackColorYellow1
    {
        background: #e6e606;
    }
    .headerBack
    {
        background: #e6e606;
        font-weight: 600;
    }
    .firstWidth
    {
        background: #fff !important;
        color: Gray !important;
    }
    td
    {
        padding: 5px 5px;
        font-family: sans-serif;
        font-size: 12px;
    }
    .Headertop
    {
        color: #a7a2a2;
        font-size: 14px;
        font-weight: 600;
    }
    .TopHeader
    {
        background: #e6e606;
        color: #007eff;
        font-weight: 600;
        font-size: 20px;
        font-family: sans-serif;
        word-spacing: 2px;
    }
    .FirstColor
    {
        color: #757373;
    }
</style>
<script src="../../js/Calender_new.js" type="text/javascript"></script>
<script src="../../js/Calender_new2.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $(".th3").datepicker({ dateFormat: 'yy-mm-dd' });
    });
    function pageLoad() {
        $(".th3").datepicker({ dateFormat: 'yy-mm-dd' });
    }
</script>
<link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
<div>
    <asp:GridView ID="grdKeyManPowerMMReport" runat="server" AutoGenerateColumns="False"
        Width="850px" HeaderStyle-CssClass="border2" HeaderStyle-HorizontalAlign="Center"
        HeaderStyle-Font-Size="13px" ShowHeader="False" ShowFooter="false" OnRowCreated="grdKeyManPowerMMReport_RowCreated"
        OnRowDataBound="grdKeyManPowerMMReport_RowDataBound">
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
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerC45Percent" runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <%-- RajeevS 10-05-2023 Start--%>
                   <%-- <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <asp:Label ID="lblManPowerBudgetD169" Text='<%#Eval("D169_Budget")%>' runat="server"></asp:Label>
                       
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <asp:Label ID="lblManPowerTodayD169" Text='<%#Eval("D169_Today")%>' runat="server"></asp:Label>
                       
                            </div>
                        </ItemTemplate>
                        <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Font-Bold="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <asp:Label ID="lblManPowerD169Percent" runat="server"></asp:Label>
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
            <%-- RajeevS 10-05-2023 End--%>

            <%--added by raghvinder on 02-11-2020 start--%>
            <%--<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerBudgetC52" Text='<%#Eval("C52_Budget")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerTodayC52" Text='<%#Eval("C52_Today")%>' runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerC52Percent" runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>--%>
            <%--added by raghvinder on 02-11-2020 end--%>
            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerBudgetBIPL" Text='<%#Eval("BIPL_Budget")%>' runat="server"></asp:Label>
                        <%--<asp:Label ID="lblManPowerBudgetBIPL" Text='<%# (int)Eval("BIPL_Budget")==0 ? "": Eval("BIPL_Budget") %>' runat="server"></asp:Label>--%>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerTodayBIPL" Text='<%#Eval("BIPL_Today")%>' runat="server"></asp:Label>
                        <%--<asp:Label ID="lblManPowerTodayBIPL" Text='<%# (int)Eval("BIPL_Today")==0 ? "": Eval("BIPL_Today") %>' runat="server"></asp:Label>--%>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="TodayBackColorYellow" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Font-Bold="false">
                <ItemTemplate>
                    <div style="text-transform: capitalize;">
                        <asp:Label ID="lblManPowerBIPLPercent" runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
