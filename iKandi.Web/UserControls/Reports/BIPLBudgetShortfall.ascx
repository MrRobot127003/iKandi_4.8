<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BIPLBudgetShortfall.ascx.cs"
    Inherits="iKandi.Web.UserControls.Reports.BIPLBudgetShortfall" %>
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
    .txtCenter
    {
        text-align: center;
    }
    td
    {
        padding: 5px 5px;
        font-family: sans-serif;
        font-size:12px;
    }
      .FirstColor
    {
        color:#757373;
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
    <%--<table width="50%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px;
        border: 1px solid #ccc;">
        <tr class="td-sub_headings border">
            <td class="heading-bg" style="width: 60px">
                <input style="text-transform: none; width: 80%;" runat="server" id="txtCreatedDate"
                    autocomplete="off" class="th3" type="text" />
            </td>
            <td align="left" width="60px" style="border-left: none; text-align: center">
                <asp:Button ID="btnsubmit" Text="Search" CssClass="submit" runat="server" OnClick="btnsubmit_Click" />
            </td>
        </tr>
    </table>--%>
    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" style="margin-bottom: 40px;">
        
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
                            <ItemStyle Width="150px" CssClass="FirstColor txtCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:Label ID="lblShortfall" Text='<%#Eval("shortfall")%>' runat="server"></asp:Label>--%>
                                <asp:Label ID="lblShortfall" Text='<%# (int)Eval("shortfall")==0 ? "": Eval("shortfall") %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="txtCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblReasonForShortfall" Text='<%#Eval("ReasonForShortFall") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblOnTrial" Text='<%#Eval("OnTrial") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="txtCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblHRremark" Text='<%#Eval("HRremarks") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <label style="color: Red">
                            NO RECORD FOUND</label></EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
