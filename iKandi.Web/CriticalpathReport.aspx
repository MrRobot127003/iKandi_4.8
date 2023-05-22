<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriticalpathReport.aspx.cs"
    EnableEventValidation="false" Inherits="iKandi.Web.CriticalpathReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="../js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../js/facebox.js"></script>
    <script type="text/javascript" src="../js/service.min.js"></script>
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
 .stitch-check tr
{
    display:flex;
}
    .stitch-check tr td span
{
    display:flex;
    align-items:center;
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
 /* My class shubhendu*/
body {font-family: Arial;}

/* Style the tab */
.tab {
  overflow: hidden;
  border: 1px solid #ccc;
  background-color: #f1f1f1;

}

/* Style the buttons inside the tab */
.tab button {
  background-color: inherit;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  /*transition: 0.3s;*/
  font-size: 17px;
}

/* Change background color of buttons on hover */
.tab button:hover {
  background-color: #ddd;
}

/* Create an active/current tablink class */
.tab button.active {
  background-color: #3a5795;
  color:White;
}

/* Style the tab content */
.tabcontent {
  display: none;
  padding: 6px 0px;
  border: 1px solid #ccc;
  border-top: none;
}
#rdb_FilterBy_SampleTracker tr
{
    display: flex;
}
#rdb_FilterBy_SampleTracker tr td
{
    display: flex;
    align-items: end;
 }
     
#rdb_FilterBy tr
{
    display: flex;
}
#rdb_FilterBy tr td
{
    display: flex;
    align-items: end;
    }
</style>
</head>
<body>
    <script type="text/javascript">

        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);
        function showCommentPopup(obj) {
            var ImgbtnRemarksIds = obj.id;
            var stylevalueId = ImgbtnRemarksIds.replace("ImgbtnRemarks", "stylevalue");
            var StyleId = $("#" + stylevalueId).val();

            proxy.invoke("Style_Remarks", { StyleId: StyleId },
                        function (result) {
                            jQuery.facebox(result);
                        }, null, false, false);
            return false;
        }

    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#DropDownList1").change(function () {
                $("#Main2").show();
                $("#maindiv").hide();
                $("#grdSampleTracker").show();
            });
            $("#BtnTrackerexcel").click(function () {
                $("#loading").show();
                $("#loading").delay(5000).fadeOut("slow");
            });
            $("#ddlDeptID").change(function () {
                $("#maindiv").show();
                $("#main2").hide();
                $("#grdcriticalpath").show();
            });
            $("#criticaltab").click(function () {
                $("#loading").show();
                $("#loading").fadeOut('slow');
            });
            $("#sampletab").click(function () {
                $("#loading").show();
                $("#loading").fadeOut('slow');
            });
        });

        
    </script>
    <script type="text/javascript">
        $(window).load(function () {
            $("#loading").fadeOut("slow");
            $("#maindiv").show();
            $("#criticaltab").addClass("active");
        });
    </script>
    <script type="text/javascript">

        function TabTest(evt, divtype) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(divtype).style.display = "block";
            evt.currentTarget.className += " active";
            var type = $("#hdntab").val(divtype);
            if (divtype == "Main2") {
                $("#title").val("Sample Tracker");
            }
            else {
                $("#title").val("Critical Path Report");
            }

        }
        $("#refimg").src;
        var src = $("#refimg").attr('src');
        if (src = "/Uploads/Style/thumb-") {
            $("#refimg").hide();
        }
    
    </script>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdntab" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="updateProgress" runat="server">
        <ProgressTemplate>
            <div id="loading">
                <img src="App_Themes/ikandi/images1/loading128.gif" alt="" style="position: fixed;
                    z-index: 52111; top: 40%; left: 45%; width: 6%;" />
                &nbsp;</div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div style="width: 1300px; margin: 0 auto;">
    </div>
    <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;
        margin-bottom: 10px; margin-top: 10px; width: 500px; margin: 5px auto; font-weight: 500;">
        Sales Report <span runat="server" id="spn_Year"></span>
    </h2>
    <%--commeneted below Grid By Girish on 2023-03-30 and added a new Grid Above--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView runat="server" ID="grdIkandiadminCommit_sales">
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
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
                 <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct1" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs13" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Apr_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                 <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs1" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct13" runat="server" Font-Bold="true" ToolTip='<%# Eval("Apr_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Apr_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Apr_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                 <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct1" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal2" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_Val", "{0:#,##}")%>'
                        Text='<%# Eval("May_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("May_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                  <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal2" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("May_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("May_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct2" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs2" runat="server" Style="color: Gray;" ToolTip='<%# Eval("May_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("May_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                  <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs2" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct2" runat="server" Font-Bold="true" ToolTip='<%# Eval("May_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("May_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("May_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                 <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct2" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal3" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jun_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal3" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jun_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                 <FooterTemplate>
                    <asp:Label ID="lblFooterValAct3" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs3" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jun_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs3" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct3" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jun_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jun_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jun_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                  <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct3" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal4" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jul_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal4" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Jul_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                 <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct4" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs4" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Jul_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                 <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs4" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct4" runat="server" Font-Bold="true" ToolTip='<%# Eval("Jul_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Jul_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Jul_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct4" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal5" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Aug_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                  <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal5" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Aug_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                 <FooterStyle CssClass="displaynone"/>
                <FooterTemplate>
                    <asp:Label ID="lblFooterValAct5" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs5" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Aug_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                  <FooterStyle CssClass="displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs5" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct5" runat="server" Font-Bold="true" ToolTip='<%# Eval("Aug_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Aug_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Aug_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                 <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct5" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblVal6" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_Val", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Sept_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                   <FooterTemplate>
                    <asp:Label ID="lblFooterVal6" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblValAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Val_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Sept_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthVal displaynone" />
                 <FooterTemplate>
                    <asp:Label ID="lblFooterValAct6" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcs6" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Sept_Psc", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                <FooterTemplate>
                    <asp:Label ID="lblFooterPcs6" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <asp:Label ID="lblPcsAct6" runat="server" Font-Bold="true" ToolTip='<%# Eval("Sept_Psc_Act", "{0:#,##}")%>'
                        Text='<%# Eval("Sept_Psc_Act").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Sept_Psc_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="minWidthPcs displaynone" />
                  <FooterTemplate>
                    <asp:Label ID="lblFooterPcsAct6" runat="server" Text=""></asp:Label>
                </FooterTemplate>
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
                            <td style="text-align: center; border-top: 1px solid #999999; height: 14px;">
                                <asp:Label ID="lblPcs7" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Oct_Psc", "{0:#,##}")%>'
                                    Text='<%# Eval("Oct_Psc").ToString() == "0" ? "" : (Convert.ToDouble(Eval("Oct_Psc").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp; &nbsp;
                                <asp:Label ID="lblPcsAct7" runat="server" Font-Bold="true" ToolTip='<%# Eval("Oct_Psc_Act", "{0:#,##}")%>'
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
                            <td style="text-align: center; height: 14px;">
                                <asp:Label ID="lblVal8" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Nov_Val", "{0:#,##}")%>'
                                    Text='<%# Eval("Nov_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Nov_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblValAct8" runat="server" Font-Bold="true" ToolTip='<%# Eval("Nov_Val_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Nov_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Nov_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; border-top: 1px solid #999999; height: 14px;">
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
                <FooterTemplate>
                    <asp:Label ID="lblFooterVal8" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="50px">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;
                        width: 100%;">
                        <tr>
                            <td style="text-align: center; height: 14px;">
                                <asp:Label ID="lblVal9" runat="server" Style="color: Gray;" ToolTip='<%# Eval("Dec_Val", "{0:#,##}")%>'
                                    Text='<%# Eval("Dec_Val").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Dec_Val").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblValAct9" runat="server" Font-Bold="true" ToolTip='<%# Eval("Dec_Val_Act", "{0:#,##}")%>'
                                    Text='<%# Eval("Dec_Val_Act").ToString() == "0" ? "" : "&#65505; " + (Convert.ToDouble(Eval("Dec_Val_Act").ToString())/1000).ToString("0") + " K" %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; border-top: 1px solid #999999; height: 14px;">
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
                 <FooterTemplate>
                    <asp:Label ID="lblFooterVal9" runat="server" Text=""></asp:Label>
                </FooterTemplate>
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
                 <FooterTemplate>
                    <asp:Label ID="lblFooterVal10" runat="server" Text=""></asp:Label>
                </FooterTemplate>
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
    </asp:GridView>--%>
    <br />
    <div id="divTab" runat="server" class="tablinks tab">
        <button class="tablinks" onclick="TabTest(event, 'maindiv');return false" id="criticaltab">
            Critical Path Report</button>
        <button class="tablinks" onclick="TabTest(event, 'Main2'); return false" id="sampletab">
            Sample Tracker</button>
    </div>
    <div id="maindiv" class="tabcontent" runat="server">
        <div style="margin-bottom: 10px; width: 100%; background: #39589c; color: #fff; font-size: 15px;
            text-align: center; vertical-align: middle; font-weight: bold; padding: 5px 15px;
            box-sizing: border-box;">
            <asp:Button ID="Button1" Style="float: left;" Text="Export to excel" OnClick="btntoExcel_Click"
                runat="server" />
            <div style="float: left; width: 84%; text-align: center;" id="title" runat="server">
                Critical Path Report
            </div>
            <div style="float: right; width: 91px; margin-top: 0px;">
                <a href='<%= (Request.IsAuthenticated) ? ResolveUrl("~/internal/Logout.aspx") : ResolveUrl("~/public/login.aspx") %>'
                    class="topmenu2border" style="text-transform: capitalize !important; color: White;
                    text-decoration: none">
                    <%= (Request.IsAuthenticated) ? "" : "" %>
                    <img src="../../Uploads/Photo/logout-critical.png" title="Log Out" alt="Log Out" /></a>
            </div>
            <div style="clear: both">
            </div>
        </div>
        <table cellpadding="0" cellspacing="0" width="100%" border="1" style="border-collapse: collapse;
            border-color: gray; margin: 0 auto">
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
            <tr>
                <th>
                    Sales Manager
                </th>
                <td>
                    <asp:Label runat="server" ID="lblSalesManager" Text=""></asp:Label>
                </td>
                <th>
                    Designer
                </th>
                <td>
                    <asp:Label runat="server" ID="lbldesigner" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="Updatepanne1" runat="server">
            <ContentTemplate>
                <div style="float: left; width: 24%; padding-left: 15px; box-sizing: border-box;
                    line-height: 40px;" id="div_ParentDeptID" runat="server">
                    <span style="padding: 0px 4px 0px 0px;">Department</span> <span>
                        <asp:DropDownList ID="ddlDeptID" runat="server" OnSelectedIndexChanged="ddl_SelectIndexChanged"
                            AutoPostBack="true" OnClientClick="javascript:return setvalue();">
                        </asp:DropDownList>
                    </span>
                </div>
                <div style="display: flex; align-items: center; width: 100%; margin: 0 auto">
                    <div style="float: left; width: 65px">
                        <asp:CheckBox ID="ChkIsAll" runat="server" Checked="true" Font-Size="12px" AutoPostBack="true"
                            Text="All" OnCheckedChanged="ChkIsAll_CheckedChanged" />
                    </div>
                    <div style="float: left;border: 1px solid #d0d0d0; background: #f2f2f2;
                        overflow-x: auto;">
                        <asp:CheckBoxList ID="ChklistClientDep" Font-Size="10px" RepeatDirection="Horizontal"
                            runat="server" CssClass="stitch-check" AutoPostBack="true" OnSelectedIndexChanged="ChklistClientDep_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </div>
                    <div>
                        <asp:RadioButtonList ID="rdb_FilterBy" runat="server" RepeatDirection="Horizontal"
                            OnSelectedIndexChanged="FilterGridBySelectedValue" AutoPostBack="true">
                            <asp:ListItem Text="Both" Value='0'></asp:ListItem>
                            <asp:ListItem Text="Shipped" Value='1'></asp:ListItem>
                            <asp:ListItem Text="UnShipped" Value='2'></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
                <br />
                <div class="divWidth" id="defaultOpen1">
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
                            <asp:TemplateField HeaderText="STC Date">
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
                            </asp:TemplateField>
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
                            <asp:TemplateField HeaderText="IkandiPrice">
                                <ItemTemplate>
                                    <asp:Label ID="lblIkandiPrice" Text='<%# "￡" + Eval("IkandiPrice").ToString() %>' runat="server"></asp:Label>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="Tokyo" class="tabcontent">
        <h1>
            Test</h1>
    </div>
    <div id="Main2" class="tabcontent" runat="server">
        <div style="margin-bottom: 10px; width: 100%; background: #39589c; color: #fff; font-size: 15px;
            text-align: center; vertical-align: middle; font-weight: bold; padding: 5px 15px;">
            <asp:Button ID="BtnTrackerexcel" Style="float: left;" Text="Export to excel" OnClick="btntoExcelTracker_Click"
                runat="server" />
            <div id="Div2" style="float: left; width: 70%; margin-top: 4px; text-align: center;"
                runat="server">
                Sample Tracker
            </div>
            <div style="float: right; width: 91px; margin-top: 0px; color: white;">
                <a href='<%= (Request.IsAuthenticated) ? ResolveUrl("~/internal/Logout.aspx") : ResolveUrl("~/public/login.aspx") %>'
                    class="topmenu2border" style="text-transform: capitalize !important; color: White!important;
                    text-decoration: none;">
                    <%= (Request.IsAuthenticated) ? "" : "" %>
                    <img src="../../Uploads/Photo/logout-critical.png" title="Log Out" alt="Log Out" />
                </a>
            </div>
            <div style="clear: both">
            </div>
        </div>
        <table cellpadding="0" cellspacing="0" width="100%" border="1" style="border-collapse: collapse;
            border-color: gray; margin: 0 auto">
            <tr>
                <th width="175px" style="display: none;">
                    Divisional Merchandising Manager
                </th>
                <td width="150px" style="display: none;">
                    <asp:Label runat="server" ID="lbldmmST" Text=""></asp:Label>
                </td>
                <th width="80px">
                    Account Manager
                </th>
                <td width="150px">
                    <asp:Label runat="server" ID="lblaccountmgrST" Text=""></asp:Label>
                </td>
                <th width="80px">
                    Fit Merchant
                </th>
                <td width="100px">
                    <asp:Label runat="server" ID="lblfitmerchantST" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Sales Manager
                </th>
                <td>
                    <asp:Label runat="server" ID="_lblSalesManager" Text=""></asp:Label>
                </td>
                <th>
                    Designer
                </th>
                <td>
                    <asp:Label runat="server" ID="_lblDesigner" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="UPnel2" runat="server">
            <ContentTemplate>
                <div style="width: 100%; height: 26px;" id="div_ParentDeptIDSt" runat="server">
                    <span style="padding: 0px 4px 0px 0px;">Department</span> <span>
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="ddl_SelectIndexChanged1"
                            AutoPostBack="true" OnClientClick="javascript:return setvalue();">
                        </asp:DropDownList>
                    </span>
                </div>
                <div style="width: 100%; margin: 0 auto">
                    <div style="float: left; width: 65px">
                        <asp:CheckBox ID="ChkBoxall1" runat="server" Checked="true" Font-Size="12px" AutoPostBack="true"
                            Text="All" OnCheckedChanged="ChkBoxall1_CheckedChanged" />
                    </div>
                    <div style="float: left;border: 1px solid #d0d0d0; background: #f2f2f2;overflow: auto;width:60%;">
                        <asp:CheckBoxList ID="Chkboxlist1" Font-Size="10px" RepeatDirection="Horizontal"
                            runat="server" CssClass="stitch-check" AutoPostBack="true" OnSelectedIndexChanged="Chkboxlist1_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </div>

                    <div>
                        <asp:RadioButtonList ID="rdb_FilterBy_SampleTracker" runat="server" RepeatDirection="Horizontal"
                            OnSelectedIndexChanged="FilterGridBySelectedValue_SampleTracker" AutoPostBack="true">
                            <asp:ListItem Text="Both" Value='0'></asp:ListItem>
                            <asp:ListItem Text="Sample Delivered" Value='1'></asp:ListItem>
                            <asp:ListItem Text="Sample Undelivered" Value='2'></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
                <br />
                <asp:GridView ID="grdSampleTracker" AllowPaging="true" AutoGenerateColumns="false"
                    runat="server" Width="100%" OnPageIndexChanging="grdSampleTracker_PageIndexChanging"
                    OnRowDataBound="grdSampleTracker_">
                    <Columns>
                        <asp:TemplateField HeaderText="Style No.">
                            <ItemTemplate>
                                <asp:Label ID="lblStyleNumber" Text='<%#Eval("StyleNumber") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sketch">
                            <ItemTemplate>
                                <div style="height: 60px; width: 60px; border: 1px solid #f3f3f3; margin: 0px auto;">
                                    <img src='<%# ResolveUrl("~/uploads/style/thumb-" + (Eval("SketchURL"))) %>' style="height: 60px !important;
                                        width: 60px !important; font-size: 9px;" alt="Image not found" runat="server"
                                        id="imgstyle" />
                                </div>
                                <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%#Eval("SketchURL") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buyer Style No.">
                            <ItemTemplate>
                                <img id="refimg" style="height: 50px; width: 50px;" runat="server" border="0" align="center"
                                    src='<%# ResolveUrl("~/Uploads/Style/thumb-" + Eval("ReferenceBlockURL").ToString()) %>'
                                    visible='<%# (Eval("ReferenceBlockURL") == null || string.IsNullOrEmpty(Eval("ReferenceBlockURL").ToString()) ) ? false: true %>' />
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sketch Recv Date.">
                            <ItemTemplate>
                                <asp:Label ID="lblSketchRecvDate" Text='<%#Eval("CreatedOn") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AWB Number">
                            <ItemTemplate>
                                <asp:Label ID="lbl_AWBNumber" Text='<%#Eval("AWBNumber") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fabric">
                            <ItemTemplate>
                                <asp:Label ID="lblFabric" Text='<%#Eval("FabricName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trims">
                            <ItemTemplate>
                                <asp:Label ID="lblTrims" Text='<%#Eval("Trims") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STATUS">
                            <ItemTemplate>
                                <asp:HiddenField ID="stylevalue" runat="server" Value='<%#Eval("Id") %>' />
                                <asp:Label ID="lblRemarks" Text='<%#Eval("Remarks") %>' runat="server"></asp:Label>
                                <asp:ImageButton ID="ImgbtnRemarks" runat="server" Height="12px" ImageUrl="~/images/comment.png"
                                    Style="float: right; padding: 1px 5px; cursor: pointer;" OnClientClick="javascript:return showCommentPopup(this)"
                                    Width="12px" />
                            </ItemTemplate>
                            <ItemStyle Width="180px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <span style="color: Red; font-weight: bold">No Record Found</span>
                    </EmptyDataTemplate>
                </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
