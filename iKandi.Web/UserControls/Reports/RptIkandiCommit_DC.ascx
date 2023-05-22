
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RptIkandiCommit_DC.ascx.cs" Inherits="iKandi.Web.UserControls.Reports.RptIkandiCommit_DC" %>
<style type="text/css">
    .HeaderClass td
    {
        background: #dddfe4;
        font-weight: bold;
        color: #575759;
        font-family: arial, halvetica;
        font-size: 12px;
        padding: 0px 0px;
        border-color: #c6c0c0;
    }
     .HeaderDepWidth
    {
        min-width: 155px;
        max-width: 155px;
     }
      .HeaderNameWidth
    {
        min-width:90px;
        max-width:90px
     }
    .minWidthTarget
    {
        min-width: 60px;
        max-width: 60px;
    }
    .minWidthActual
    {
        max-width: 60px;
        min-width: 60px;
    }
   
    .minWidthVal
    {
        max-width: 60px;
        min-width: 60px;
    }
    .minWidthTarVal
    {
        max-width: 60px;
        min-width: 60px;
    }
     .minWidthValLa
    {
        max-width: 60px;
        min-width: 60px;
    }
    .minWidthTarValLa
    {
        max-width: 60px;
        min-width: 60px;
    }
   .minWidthHeActual
   {
        min-width: 60px;
        max-width: 60px;
    }
   .minWidthHeTarget
   {
        min-width: 60px;
        max-width: 60px;
    }
   
   
    .minParDep
    {
        min-width: 155px;
        max-width: 155px;
     }
     .minComName
    {
        min-width:91px;
        max-width:91px
     }
   
    
     .TopHeader
     {
        text-align:left;
         padding-left:5px !important;
      }
     .TopHeaderc
      {
         text-align:left;  
         padding-left:5px !important;
         background:#eeececd4 !important;
       }
       
     .TopHeaderCurr
     {
         background:#eeececd4 !important;
     }
    
    .grdTableWidth
    {
       width:100%;
     }
   
     #RptIkandiCommit_DC1_grdIkandiadminCommit_sales .minComName
     {
           min-width: 88px;
          max-width: 88px;
      }
       #RptIkandiCommit_DC1_grdIkandiadminCommit_sales .minParDep
     {
           min-width: 153px;
          max-width: 153px;
      }
     #RptIkandiCommit_DC1_grdIkandiadminCommit_salesFreeze .minParDep
     {
         
        min-width: 153px;
        max-width: 153px;
     }
      #RptIkandiCommit_DC1_grdIkandiadminCommit_salesFreeze .minComName
     {
           min-width: 88px;
          max-width: 88px;
      }
     #RptIkandiCommit_DC1_grdIkandiadminCommit_sales .minWidthVal
    {
         min-width: 58px;
         max-width: 58px;
    }
      #RptIkandiCommit_DC1_grdIkandiadminCommit_sales .minWidthTarVal
    {
         min-width: 58px;
         max-width: 58px;
    }
     #RptIkandiCommit_DC1_grdIkandiadminCommit_salesPanelItemContent .minWidthValLa
    {
         min-width: 58px;
         max-width: 58px;
    }
      #RptIkandiCommit_DC1_grdIkandiadminCommit_salesPanelItemContent .minWidthTarValLa
    {
         min-width: 58px;
         max-width: 58px;
    }
    #RptIkandiCommit_DC1_grdIkandiadminCommit_salesPanelItemContentFreeze
    {
        width:248px;
    }
    .revenue_img_table img
    {
        width:100%;
        }
     
</style>
<script src="../../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
<script src="../../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
<script src="../../js/gridviewScroll.min.js" type="text/javascript"></script>
<link href="../../css/GridviewScroll.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        var gridWidth = $(window).width() - 50;
        var gridHeight = $(window).height() - 80;
        $('#<%=grdIkandiadminCommit_sales.ClientID%>').gridviewScroll({
            width: gridWidth,
            height: 450,
            arrowsize: 30,
            varrowtopimg: "../../images/arrowvt.png",
            varrowbottomimg: "../../images/arrowvb.png",
            harrowleftimg: "../../images/arrowhl.png",
            harrowrightimg: "../../images/arrowhr.png",
            freezesize: 2,
            headerrowcount: 4
        });
        $("#rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_sales_ctl06_lblParentDept").parent().css("background-color", "yellow");
    });
</script>
<asp:GridView ID="grdIkandiadminCommit_sales" runat="server" AutoGenerateColumns="false"
    ShowFooter="True" ShowHeader="false" CssClass="grdTableWidth" FooterStyle-Font-Bold="true"
    OnRowDataBound="grdIkandiadminCommit_sales_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
            </ItemTemplate>
             <ItemStyle CssClass="minComName" />
            <FooterTemplate>
                <asp:Label ID="lblTotal" runat="server" Text="Total" CssClass="FloatRight"></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblParentDept" runat="server" Text='<%# Eval("ParentDept") %>'></asp:Label>
            </ItemTemplate>
             <ItemStyle CssClass="minParDep" />
            <FooterTemplate>
            </FooterTemplate>
           
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal1" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Apr_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal1" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct1" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Apr_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct1" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs1" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs1" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct1" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct1" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal2" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_Val", "{0:#,##}")%>'
                    Text='<%# Eval("May_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("May_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal2" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("May_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("May_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct2" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs2" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("May_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs2" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("May_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct2" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal3" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jun_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal3" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jun_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct3" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs3" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs3" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct3" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal4" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jul_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal4" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jul_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct4" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs4" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs4" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct4" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal5" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Aug_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal5" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Aug_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct5" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs5" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs5" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct5" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal6" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Sept_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal6" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Sept_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct6" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs6" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs6" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct6" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal7" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Oct_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Oct_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal7" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct7" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Oct_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Oct_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct7" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs7" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_Psc", "{0:#,##}")%>'
                    Text='<%# (Eval("Oct_Psc").ToString() == "0"||Eval("Oct_Psc").ToString() == "") ? "" : (Convert.ToDouble(Eval("Oct_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs7" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct7" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Oct_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct7" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal8" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Nov_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal8" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct8" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Nov_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct8" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs8" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs8" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct8" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct8" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal9" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Dec_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal9" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct9" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Dec_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct9" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs9" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs9" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct9" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct9" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal10" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jan_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Jan_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jan_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterVal10" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct10" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jan_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jan_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jan_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct10" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs10" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jan_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Jan_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jan_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs10" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct10" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jan_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jan_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jan_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle CssClass="minWidthVal" />
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct10" runat="server" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal11" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Feb_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Feb_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Feb_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal11" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct11" runat="server" Font-Bold="true" ToolTip='<%# Eval("Feb_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Feb_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Feb_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct11" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthVal" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs11" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Feb_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Feb_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Feb_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs11" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct11" runat="server" Font-Bold="true" ToolTip='<%# Eval("Feb_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Feb_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Feb_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct11" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthVal" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal12" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Mar_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Mar_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Mar_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal12" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct12" runat="server" Font-Bold="true" ToolTip='<%# Eval("Mar_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Mar_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Mar_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct12" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthVal" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs12" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Mar_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Mar_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Mar_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs12" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarVal" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct12" runat="server" Font-Bold="true" ToolTip='<%# Eval("Mar_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Mar_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Mar_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct12" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthVal" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal13" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Apr_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal13" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct13" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Apr_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct13" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs13" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs13" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct13" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Apr_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct13" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal14" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("May_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("May_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal14" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct14" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("May_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("May_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct14" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs14" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("May_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs14" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct14" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("May_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct14" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal15" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jun_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal15" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct15" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jun_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct15" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs15" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs15" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct15" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jun_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct15" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal16" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jul_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal16" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct16" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Jul_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct16" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs16" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs16" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct16" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Jul_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct16" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

         <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal17" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Aug_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal17" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct17" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Aug_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct17" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs17" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs17" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct17" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Aug_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct17" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal18" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Sept_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal18" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct18" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Sept_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct18" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs18" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs18" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct18" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Sept_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct18" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal19" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Oct_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Oct_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal19" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct19" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Oct_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Oct_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct19" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs19" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Oct_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs19" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct19" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Oct_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct19" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal20" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Nov_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal20" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct20" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Nov_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct20" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs20" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs20" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct20" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Nov_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct20" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblVal21" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_2019_Val", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_2019_Val").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Dec_2019_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterVal21" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblValAct21" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_2019_Val_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_2019_Val_Act").ToString() == "0" ? "" : "£ " + (Convert.ToDouble(Eval("Dec_2019_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterValAct21" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcs21" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_2019_Psc", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_2019_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_2019_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcs21" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthTarValLa" />
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lblPcsAct21" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_2019_Psc_Act", "{0:#,##}")%>'
                    Text='<%# Eval("Dec_2019_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_2019_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblFooterPcsAct21" runat="server" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle CssClass="minWidthValLa" />
        </asp:TemplateField>

    </Columns>
    <EmptyDataTemplate>
        No Record Found
    </EmptyDataTemplate>
</asp:GridView>
