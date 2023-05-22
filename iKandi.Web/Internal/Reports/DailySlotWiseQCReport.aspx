<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailySlotWiseQCReport.aspx.cs" Inherits="iKandi.Web.Internal.Reports.DailySlotWiseQCReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-1.4.4.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui-1.8.6.custom.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/facebox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/js.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ImageFaceBox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/thickbox.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.lightbox-0.5.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.min.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.dataTables.js ")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.mask.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/service.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-ui.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.ajaxQueue.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.bgiframe.min.js")%>'></script>
<script type="text/javascript" src='<%=Page.ResolveUrl("~/js/form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/colorpicker.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>

    <script type="text/javascript">


        $(function () {
            //            $(".th3").datepicker({ dateFormat: 'dd/mm/yy' });
            var RptMINDate = new Date().addDays(-60);
            var RptMAXDate = new Date().addDays(0);
            $(".RptDate").datepicker({ dateFormat: "dd M y (D)", minDate: RptMINDate, maxDate: RptMAXDate }).val();

        });     


        //        function pageLoad() {

        //            
        //            
        //            $(".th3").datepicker({ dateFormat: "dd M y (D)" });
        //            MyDatePickerFunction();
        ////            jQuery(function () {
        ////                var date = new Date();
        ////                var currentMonth = date.getMonth();
        ////                var currentDate = date.getDate();
        ////                var currentYear = date.getFullYear();

        ////                $('.th3').datepicker({
        ////                    minDate: new Date(currentYear, currentMonth - 1, currentDate),
        ////                    maxDate: new Date(currentYear, currentMonth, currentDate)
        ////                });
        ////            });            
        //        }

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

        //      
    </script>

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
            background:yellow;
        }
    </style>


    <link href="../../css/technical-module.css" type="text/css" rel="Stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:HiddenField ID="hdn_cmt_workingdays" runat="server" Value="0" />

        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="main_tbl_wrapper"
            bgcolor="#ffffff" style="padding: 0px 10px">

                       
                                               
            <tr>
                <td>
                             
                    <table width="70%" border="0" align="center" cellspacing="0" cellpadding="3" style="margin: 0px;
                        border: 1px solid #ccc;">
                            <tr>
                            <td colspan="3">
                                <h2 style="background: #3a5795; padding: 5px 0px; color: #fff; text-align: center;">
                                    Daily Slot Wise QC Report
                                </h2>
                            </td>
                        </tr>
                        <tr class="td-sub_headings border">
                                            
                            <td class="heading-bg" style="width: 30px">
                                Date
                            </td>
                            <td class="heading-bg" style="width: 60px">                                                  
                                    <asp:TextBox ID="txtQCDate" runat="server" CssClass="RptDate"></asp:TextBox>                                                        
                            </td>
                            <td align="left" width="60px" style="border-left: none;">
                                <asp:Button ID="btnsubmit" Text="Search" CssClass="submit" runat="server" onclick="btnsubmit_Click" />
                            </td>
                        </tr>
                    </table>

                                        
                    <table width="70%" border="0" align="left" cellpadding="0" cellspacing="0">
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
                            <div runat="server" id="frmQCReport" >
                            </div>
                                             
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
