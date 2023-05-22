<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCriticalPathReports_BIPL.aspx.cs" Inherits="iKandi.Web.Internal.Merchandising.frmCriticalPathReports_BIPL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script src="../js/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../css/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
  

    </script>
    <style type="text/css">
        body
        {
            font-family:Arial;
            text-transform:capitalize;
            font-size:10px;
            color:Black;
            font-weight:bold;
        }
    th
    {
        background-color: #39589c;
        color: #ffffff !important;
        font-size: 11px !important;
        padding:5px;
        min-width:55px;
        font-weight: 500;
        font-family: Arial;
    }
    td
    {
        padding:1px 2px;
     }
    #ChklistClientDep input
    {
     margin:0px 5px; 
     padding:0px;   
    }
    #ChklistClientDep label
    {
        vertical-align:top;
    }
    .stitch-check td
{
    white-space: nowrap;
    word-wrap: normal;
    
}
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
    .minWidthTarget
    {
        min-width: 60px;
    }
    .minWidthActual
    {
        min-width: 50px;
    }
    .minWidthVal
    {
        min-width: 60px;
    }
    .minWidthPcs
    {
        min-width: 50px;
    }
   /*   #grdIkandiadminCommit_salesPanelItemContentFreeze
    {
        width: 1320px !important;
    }
     #grdIkandiadminCommit_salesPanelItemContent
    {
        width: 1320px !important;
    }
    #grdIkandiadminCommit_salesPanelHeaderContent
    {
        width: 1320px !important;
    }
     #grdIkandiadminCommit_salesPanelHeader
    {
        width: 1320px !important;
    }
     #grdIkandiadminCommit_salesPanelItem
    {
        width: 1320px !important;
    }
    #grdIkandiadminCommit_salesWrapper  {
        width: 1320px !important;
    }
    #grdIkandiadminCommit_salesHorizontalRail
    {
        width: 1280px !important;
        }
    #grdIkandiadminCommit_salesHorizontal_RIMG
    {
         left: 1290px !important;
        }
    #rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_salesPanelItemContentFreeze
    {
        max-width: 208px;
    }
    
    #rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_sales
    {
        min-width: 4208px;
        border-collapse: collapse;
        table-layout: fixed;
    }
    #rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_salesCopy
    {
        min-width: 4196px;
        border-collapse: collapse;
        table-layout: fixed;
    }
    .GridCellDiv
    {
       
    }
   #grdIkandiadminCommit_salesPanelItemContentFreeze
    {
      width: 191px !important;   
    }
    #rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_salesPanelItemContentFreeze
    {
        background: rgb(255, 255, 255);
        overflow: hidden;
        height: 389px;
        z-index: 0;
        position: absolute;
        top: 0px;
        left: 0px;
        width: 203px;
    }*/
   /* #rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_salesCopyFreeze
    {
        width: 204px;
    }
    #rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_sales_ctl08_lblParentDept
    {
        word-break: break-all;
    }
    .GridCellDiv span
    {
        word-break: break-all;
    }
    #rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_salesCopy
    {
        width: 4208px !important;
    }*/
 
    .minParDep
    {
        min-width:91px;
         text-align:center;
     }
      .minComName
    {
        min-width:91px;
        text-align:center;
     }
     grid_scroll
{
    overflow: auto;
    height: 500px;
    border: solid 1px orange;
    height: 480px;
    width: 800px;
}



 #scrolledGridView
    {
        overflow-x: scroll; 
        text-align: left;
        width: 400px; /* i.e. too small for all the columns */
    }

    .pinned
    {
        position: fixed; /* i.e. not scrolled */
        background-color: White; /* prevent the scrolled columns showing through */
        z-index: 100; /* keep the pinned on top of the scrollables */
    }
    .scrolled
    {
        position: relative;
        left: 150px; /* i.e. col1 Width + col2 width */
        overflow: hidden;
        white-space: nowrap;
        min-width: 500px; /* set your real column widths here */
    }
    .Clients
    {
        left: 0px;
        width: 50px;
    }
    .Parent Dept.
    {
        left: 50px; /* i.e. col1 Width */
        width: 100px;
    }
    .textcenter
    {
        text-align:center;
      }
      .bordertab{
       
         border-left: 1px solid #999999;
         border-right: 1px solid #999999;
      }
      .bordertabfreez{
       
         border-left: 1px solid #999999;
         border-right: 1px solid #999999;
      }
    /*  #grdIkandiadminCommit_salesPanelHeaderContent td{
    padding-left: 2px;
}
    #grdIkandiadminCommit_salesPanelItemContent  td{
    padding-left: 2px;
}
#grdIkandiadminCommit_salesCopyFreeze td{
    padding-left: 2px;
}
#grdIkandiadminCommit_salesFreeze td{
    padding-left: 2px;
}*/
.displaynone
{

      display:none ;

}
.displayblock
{
  /* display:block;*/
}  
.displayblocks
{
    display: table-cell;
} 
.RedBorder
{
 
    border-right: 1px solid red;
    border-bottom: 1px solid red; 
}
.BorderPerRight
{
    border-right: 1px solid red;
    }
#grdIkandiadminCommit_sales
{
    width:500px !important;
    margin: 0 auto;
   
 }
 .tableborderoct
 {
     border-right: 1px solid #b70505;
   
     }
.tablebordernov
 {
     border-right: 1px solid #b70505;
    border-bottom: 1px solid #b70505;
     } 
   .divWidth
   { 
       max-width:1360px;
       overflow:auto;
     }
</style>
</head>
<body>
    <script type="text/javascript">
        //        $(document).ready(function () {
        //            $('#grdcriticalpath').removeAttr('border');
        //                        var gridWidth = $(window).width() - 50;
        //                        var gridHeight = $(window).height() - 80;
        //                        $('#<%=grdcriticalpath.ClientID%>').gridviewScroll({
        //                            width: gridWidth,
        //                            height: 500,
        //                            arrowsize: 30
        ////                            varrowtopimg: "../images/arrowvt.png",
        ////                            varrowbottomimg: "../images/arrowvb.png",
        ////                            harrowleftimg: "../images/arrowhl.png",
        ////                            harrowrightimg: "../images/arrowhr.png",
        ////                            freezesize: 2,
        ////                            headerrowcount: 3
        //                        });
        //                        // $("#rpt_IkandiAdminCommit_Sales1_grdIkandiadminCommit_sales_ctl06_lblParentDept").parent().css("background-color", "yellow");
        //                        $("#grdIkandiadminCommit_sales, #grdIkandiadminCommit_salesFreeze").removeAttr('border');
        //                        $("#grdIkandiadminCommit_sales").addClass('bordertab');
        //                        $("#grdIkandiadminCommit_salesFreeze").addClass('bordertabfreez');

        //        });

    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width:1300px; margin: 0 auto;">
      <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;
        margin-bottom: 10px; margin-top: 10px; width: 500px;margin: 5px auto; font-weight: 500;">
        Ikandi Sales Target Report (2019 - 2020)</h2>
    <%--<div id="popup" style="max-height:600px;overflow-y:scroll;">--%>
    <asp:GridView ID="grdIkandiadminCommit" runat="server" AutoGenerateColumns="false"
        ShowFooter="True" ShowHeader="false" Width="100%" FooterStyle-Font-Bold="true"
        OnRowDataBound="grdIkandiadminCommit_sales_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="pinned col1"></HeaderStyle>
                <ItemStyle CssClass="pinned col1 minComName"></ItemStyle>
                <FooterTemplate>
                    <asp:Label ID="lblTotal" runat="server" Text="Total" CssClass="FloatRight"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lblParentDept" runat="server" Text='<%# Eval("ParentDept") %>'></asp:Label>
                </ItemTemplate>
                <%--<ItemStyle CssClass="minParDep" />--%>
                <HeaderStyle CssClass="pinned col2"></HeaderStyle>
                <ItemStyle CssClass="pinned col2"></ItemStyle>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal1" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Apr_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal1" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct1" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Apr_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs1" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct1" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct1" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal2" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_Val", "{0:#,##}")%>'
                        Text='<%# Eval("May_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("May_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal2" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("May_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("May_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs2" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("May_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct2" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal3" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jun_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal3" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jun_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs3" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct3" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal4" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jul_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal4" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jul_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs4" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct4" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal5" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Aug_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal5" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Aug_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs5" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct5" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal6" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Sept_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal6" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Sept_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs6" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct6" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal7" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Oct_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Oct_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal7" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct7" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Oct_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Oct_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct7" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs7" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Oct_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs7" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct7" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Oct_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct7" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal8" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Nov_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Nov_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal8" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct8" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Nov_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Nov_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs8" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct8" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Nov_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct8" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal9" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Dec_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Dec_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal9" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct9" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Dec_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Dec_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs9" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct9" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Dec_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct9" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal10" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jan_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Jan_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jan_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal10" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct10" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jan_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jan_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jan_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs10" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct10" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jan_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jan_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jan_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct10" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal11" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Feb_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Feb_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Feb_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal11" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <ItemStyle CssClass="minWidthVal" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct11" runat="server" Font-Bold="true" ToolTip='<%# Eval("Feb_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Feb_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Feb_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct11" runat="server" Font-Bold="true" ToolTip='<%# Eval("Feb_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Feb_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Feb_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct11" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <ItemStyle CssClass="minWidthPcs" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal12" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Mar_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Mar_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Mar_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal12" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <ItemStyle CssClass="minWidthVal" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct12" runat="server" Font-Bold="true" ToolTip='<%# Eval("Mar_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Mar_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Mar_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
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
                <ItemStyle CssClass="minWidthPcs" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct12" runat="server" Font-Bold="true" ToolTip='<%# Eval("Mar_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Mar_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Mar_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct12" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <ItemStyle CssClass="minWidthPcs" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No Record Found
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:GridView ID="grdIkandiadminCommit_sales" runat="server" AutoGenerateColumns="false"
        ShowFooter="false" ShowHeader="false" Width="100%" FooterStyle-Font-Bold="true"
        OnRowDataBound="grdIkandiadminCommit_sales_RowDataBound">
        <Columns>
        
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal13" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Apr_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                     
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
              
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct13" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Apr_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%-- <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct1" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs13" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%-- <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs1" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct13" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%-- <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct1" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal2" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_Val", "{0:#,##}")%>'
                        Text='<%# Eval("May_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("May_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%--  <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal2" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("May_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("May_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%--<FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct2" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs2" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("May_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%--  <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs2" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("May_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%-- <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct2" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal3" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jun_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%--<FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal3" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jun_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%-- <FooterTemplate>
                    <asp:Label ID="lblFooterValAct3" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs3" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%--<FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs3" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%--  <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct3" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal4" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jul_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%--<FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal4" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jul_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%-- <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct4" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs4" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%-- <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs4" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%--<FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct4" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal5" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Aug_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%--  <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal5" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Aug_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%-- <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct5" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs5" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%--  <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs5" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%-- <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct5" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal6" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Sept_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%--   <FooterTemplate>
                    <asp:Label ID="lblFooterVal6" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Sept_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%-- <FooterTemplate>
                    <asp:Label ID="lblFooterValAct6" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs6" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%--<FooterTemplate>
                    <asp:Label ID="lblFooterPcs6" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <%--  <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct6" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%;">
                        <tr>
                            <td style="text-align: center; height: 14px;">
                                <asp:Label ID="lblVal7" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_Val", "{0:#,##}")%>'
                                    Text='<%# Eval("Oct_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Oct_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp; 
                                <asp:Label ID="lblValAct7" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_Val_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Oct_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Oct_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;border-top: 1px solid #999999;  height: 14px;">
                                <asp:Label ID="lblPcs7" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_Psc", "{0:#,##}")%>'
                                    Text='<%# Eval("Oct_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp; &nbsp; <asp:Label ID="lblPcsAct7" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_Psc_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Oct_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal tableborderoct displaynone" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                  <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%;">
                        <tr> 
                          <td style="text-align:center;height: 14px;">
                           <asp:Label ID="lblVal8" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Nov_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Nov_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;  <asp:Label ID="lblValAct8" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Nov_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Nov_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                          </td>
                        </tr>
                        <tr> 
                          <td style="text-align:center;border-top: 1px solid #999999;height: 14px;">
                            <asp:Label ID="lblPcs8" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Nov_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;  
                          <asp:Label ID="lblPcsAct8" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Nov_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Nov_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                          </td>
                        </tr>
                   </table>
                   
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%--<FooterTemplate>
                    <asp:Label ID="lblFooterVal8" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>    
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                 <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%; ">
                        <tr> 
                          <td style="text-align:center;height: 14px;">
                            <asp:Label ID="lblVal9" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Dec_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Dec_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblValAct9" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Dec_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Dec_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                        </td>
                        </tr>
                        <tr> 
                          <td style="text-align:center;border-top: 1px solid #999999;height: 14px;">
                            <asp:Label ID="lblPcs9" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Dec_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;  
                          <asp:Label ID="lblPcsAct9" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Dec_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Dec_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                          </td>
                        </tr>
                   </table>
                   
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%-- <FooterTemplate>
                    <asp:Label ID="lblFooterVal9" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%;">
                        <tr>
                            <td style="text-align: center; height: 14px;">
                                <asp:Label ID="lblVal10" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jan_Val", "{0:#,##}")%>'
                                    Text='<%# Eval("Jan_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jan_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblValAct10" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jan_Val_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Jan_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jan_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; border-top: 1px solid #999999; height: 14px;">
                                <asp:Label ID="lblPcs10" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jan_Psc", "{0:#,##}")%>'
                                    Text='<%# Eval("Jan_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jan_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblPcsAct10" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jan_Psc_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Jan_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jan_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <%-- <FooterTemplate>
                    <asp:Label ID="lblFooterVal10" runat="server" Text=""></asp:Label>
                </FooterTemplate>--%>
            </asp:TemplateField>
           
           <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%;">
                        <tr>
                            <td style="text-align: center; height: 14px;">
                                <asp:Label ID="lblVal11" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Feb_Val", "{0:#,##}")%>'
                                    Text='<%# Eval("Feb_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Feb_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblValAct11" runat="server" Font-Bold="true" ToolTip='<%# Eval("Feb_Val_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Feb_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Feb_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; border-top: 1px solid #999999; height: 14px;">
                                <asp:Label ID="lblPcs11" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Feb_Psc", "{0:#,##}")%>'
                                    Text='<%# Eval("Feb_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Feb_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblPcsAct11" runat="server" Font-Bold="true" ToolTip='<%# Eval("Feb_Psc_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Feb_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Feb_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
              
            </asp:TemplateField>
           
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%;">
                        <tr>
                            <td style="text-align: center; height: 14px;">
                                <asp:Label ID="lblVal12" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Mar_Val", "{0:#,##}")%>'
                                    Text='<%# Eval("Mar_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Mar_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblValAct12" runat="server" Font-Bold="true" ToolTip='<%# Eval("Mar_Val_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Mar_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Mar_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; border-top: 1px solid #999999; height: 14px;">
                                <asp:Label ID="lblPcs12" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Mar_Psc", "{0:#,##}")%>'
                                    Text='<%# Eval("Mar_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Mar_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblPcsAct12" runat="server" Font-Bold="true" ToolTip='<%# Eval("Mar_Psc_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Mar_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Mar_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
              
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%;">
                        <tr>
                            <td style="text-align: center; height: 14px;">
                                <asp:Label ID="lblVal1" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Val", "{0:#,##}")%>'
                                    Text='<%# Eval("Apr_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Apr_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblValAct1" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Val_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Apr_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Apr_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; border-top: 1px solid #999999; height: 14px;">
                                <asp:Label ID="lblPcs1" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Psc", "{0:#,##}")%>'
                                    Text='<%# Eval("Apr_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblPcsAct1" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Psc_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Apr_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
              
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No Record Found
        </EmptyDataTemplate>
    </asp:GridView>
     <br />
     <div style="margin-bottom: 10px; width: 100%; background: #39589c; color: #fff;
        font-size: 15px; text-align: center; vertical-align: middle; font-weight: 500;
        padding: 5px 0px;">
        <asp:Button ID="Button1" Style="float: left;" Text="Export to excel" OnClick="btntoExcel_Click"
            runat="server" />
        <div style="float: left; width: 70%;font-weight:500; margin-top: 4px; text-align: center;">
            Critical Path Report
        </div>
        <div style="float: right; width: 91px; margin-top: 0px;">
            <a href='<%= (Request.IsAuthenticated) ? ResolveUrl("~/internal/Logout.aspx") : ResolveUrl("~/public/login.aspx") %>'
                class="topmenu2border" style="text-transform: capitalize !important;">
                <%= (Request.IsAuthenticated) ? "" : "" %>
                <img src="../../Uploads/Photo/logout-critical.png" title="Log Out" alt="Log Out" /></a>
        </div>
        <div style="clear: both">
        </div>
    </div>
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <table cellpadding="0" cellspacing="0" width="100%" border="1" style="border-collapse: collapse;
        border-color: gray;margin:0 auto"">
        <tr>
            <th width="175px" style="display: none;">
                Divisional Merchandising Manager
            </th>
            <td width="150px" style="display: none;">
                <asp:Label runat="server" ID="lbldmm" Text=""></asp:Label>
            </td>
            <th width="80px">
                Account Manager
            </th>
            <td width="150px">
                <asp:Label runat="server" ID="lblaccountmgr" Text=""></asp:Label>
            </td>
            <th width="80px">
                Fit Merchant
            </th>
            <td width="100px">
                <asp:Label runat="server" ID="lblfitmerchant" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 1300px; margin:0 auto">
        <div style="float: left; width: 65px">
            <asp:CheckBox ID="ChkIsAll" runat="server" Checked="true" Font-Size="12px" AutoPostBack="true"
                Text="All" OnCheckedChanged="ChkIsAll_CheckedChanged" />
        </div>
        <div style="float: left; width: 1232px; border: 1px solid #d0d0d0; background: #f2f2f2;
            overflow-x: scroll;">
            <asp:CheckBoxList ID="ChklistClientDep" Font-Size="10px" RepeatDirection="Horizontal"
                runat="server" CssClass="stitch-check" AutoPostBack="true" OnSelectedIndexChanged="ChklistClientDep_SelectedIndexChanged">
            </asp:CheckBoxList>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <br />
   
    
    <%--</div>--%>
   <div class="divWidth">
    <asp:GridView ID="grdcriticalpath" AllowPaging="true" AutoGenerateColumns="false"
        OnPageIndexChanging="grdcriticalpath_PageIndexChanging" OnRowDataBound="grdcriticalpath_RowDataBound"
        runat="server" Width="100%">
        <Columns>
          <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="lblDept" Text='<%#Eval("DepartmentName") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="130px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <div style="height: 60px; width: 60px; border: 1px solid #f3f3f3; margin: 0px auto;">
                        <img src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("SampleImageURL1"))) %>'
                            style="height: 60px !important; width: 60px !important; font-size: 9px;" alt="Image not found"
                            runat="server" id="imgstyle" />
                        <%--<asp:Label ID="lblurl" runat="server"></asp:Label>
          <asp:HyperLink ID="hy" runat="server"></asp:HyperLink>--%>
                    </div>
                    <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%#Eval("SampleImageURL1") %>' />
                </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier Reference">
                <ItemTemplate>
                    <asp:Label ID="lblstyleNo" Text='<%#Eval("StyleNumber") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Department Category">
                <ItemTemplate>
                    <asp:Label ID="lblDeptCatg" Text='<%#Eval("DepartmentCatg") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Style">
                <ItemTemplate>
                    <asp:Label ID="lblbuyerstylenumber" Text='<%#Eval("LineItemNumber") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Style Description">
                <ItemTemplate>
                    <asp:Label ID="lblorderDiscription" Text='<%#Eval("Description") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="180px" HorizontalAlign="Center" />
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="PO Number">
                <ItemTemplate>
                    <asp:Label ID="lblPoNumber" Text='<%#Eval("PoNumber") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="MDA">
                <ItemTemplate>
                    <asp:Label ID="lblMDA" Text='<%#Eval("MDA") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Initial ExFactory Date">
                <ItemTemplate>
                    <asp:Label ID="lblInitialExFactoryDate" Text='<%#Eval("ETD") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
         <%--   <asp:TemplateField HeaderText="ikandi price">
                <ItemTemplate>
                    <asp:Label ID="lblikandiPrice" ToolTip="ikandi price" Text='<%#Eval("iKandiPrice") %>'
                        runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnCurrenyTag" runat="server" Value='<%#Eval("convertto")%>' />
                </ItemTemplate>
                <ItemStyle Width="60px" HorizontalAlign="Center" />
            </asp:TemplateField>--%>
          <%--  <asp:TemplateField HeaderText="Fabric in house date">
                <ItemTemplate>
                    <asp:Label ID="lblFabricBihDate" Text='<%#Eval("FabricBIHdate") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>--%>
          <%--  <asp:TemplateField HeaderText="Accsessory in house date">
                <ItemTemplate>
                    <asp:Label ID="lblAccsessoryBihdate" Text='<%#Eval("AccsessoryBIHdate") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>--%>
           <%-- <asp:TemplateField HeaderText="STC Date">
                <ItemTemplate>
                    <asp:Label ID="lblTechnicalBihdate" Text='<%#Eval("STCBIHdate") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fits/TOP status">
                <ItemTemplate>
                    <asp:Label ID="lblFitsStatus" Text='<%#Eval("FitsStatus") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="140px" HorizontalAlign="Center" />
            </asp:TemplateField>--%>
         <%--   <asp:TemplateField HeaderText="Mode">
                <ItemTemplate>
                    <asp:Label ID="lblmode" Text='<%#Eval("Code") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Delivery Date">
                <ItemTemplate>
                    <asp:Label ID="lblDcdate" Text='<%#Eval("DC") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>                  
                        <asp:TemplateField HeaderText="Fulfilment Center">
                <ItemTemplate>
                    <asp:Label ID="lblFulfilmentCenter" Text='<%#Eval("FulfilmentCenter") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="PO Quantity Units">
                <ItemTemplate>
                    <asp:Label ID="lblunits" Text='<%#Eval("Quantity") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="IKandi Order Reference">
                <ItemTemplate>
                    <asp:Label ID="lblserialNo" Text='<%#Eval("SerialNumber") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order Status">
                <ItemTemplate>
                    <asp:Label ID="lblOrderStatus" Text='<%#Eval("OrderStatus") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="IKandi Shipped Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblShippedQty" Text='<%#Eval("ShippedQty") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shipment Mode">
                <ItemTemplate>
                    <asp:Label ID="lblShippedMode" Text='<%#Eval("ShippedMode") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="ETD">
                <ItemTemplate>
                    <asp:Label ID="lblEID" Text='<%#Eval("ETD") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="ETA to Warehouse">
                <ItemTemplate>
                    <asp:Label ID="lblETA_to_WareHouse" Text='<%#Eval("ETA_to_WareHouse") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="IKandi Comments">
                <ItemTemplate>
                    <asp:Label ID="lblIkandiComment" Text='<%#Eval("IkandiComment") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <span style="color: Red; font-weight: bold">No Record Found</span>
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    </div>
    </div>
 
       <asp:Button ID="btntoExcel" Text="Export to excel" OnClick="btntoExcel_Click" runat="server"  style="margin-left:150px" />

    <%--/ContentTemplate>
        <Triggers>
      <asp:PostBackTrigger ControlID="btntoExcel" />
        </Triggers>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>