<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCMTCalculator.aspx.cs"
    Inherits="iKandi.Web.Internal.Merchandising.frmCMTCalculator" %>
<html>
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../../js/combined_jquery_scripts4.js"></script>
    <style>
        .AddClass_Table th
        {
            text-align: right;
            font-size: 15px;
            background: #f0eaea;
            color: #625f5f;
            height: 30px;
              padding: 3px 5px;
        }
        .AddClass_Table td input[type='text']
        {
            width: 100% !important;
            height: 23px;
            margin: 3px 0px;
            padding: 3px 4px;
            border-radius: 3px;
            font-size: 15px;
            border:0px;
        }
        .AddClass_Table td
        {
            font-size: 14px;
        }
        #ui-datepicker-div
        {
            padding:0px 0px !important;
            display:none;
            }
            .ui-helper-clearfix:after {
            content: ".";
            display: block;
            height: 0;
            clear: both;
            visibility: hidden;
            display:none;
        }
    </style>
</head>
<body>
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/progress.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.validate.min.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery-jtemplates.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.form.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/ui.core.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/iKandi.js")%>'></script>
    <%--<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>--%>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.autocomplete.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.fixedtableheader-1-0-2.min.js")%>'></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.easydrag.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.jqprint.0.3.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.MultiFile.pack.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.hoverIntent.min.js")%>' type="text/javascript"></script>
    <%-- <script src='<%= Page.ResolveUrl("~/js/jquery.simpletip-1.3.1.pack.js")%>' type="text/javascript"></script>--%>
    <script src='<%= Page.ResolveUrl("~/js/jquery.tools.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/jquery.checkbox.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/js/fna.js")%>' type="text/javascript"></script>
    <%--<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
     <link href="../css/colorbox.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.9.0-jquery.min.js" type="text/javascript"></script>
    <script src="../js/jqueryui-1.9.1-jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-1.4.4.min.js">'></script>
    <script type="text/javascript" src="../js/service.min.js"></script>
    <script type="text/javascript" src="../js/jquery.autocomplete.js"></script>
    <script src="../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript" src="../js/combined_jquery_scripts4.js"></script>
    <script type="text/javascript" src="../js/form.js"></script>--%>
    <script src="../../js/Calender_new.js" type="text/javascript"></script>
    <script src="../../js/Calender_new2.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $(".CMTCalender").datepicker({ dateFormat: 'dd M y (D)' });
            //$(".DateWithoutYear").datepicker({ dateFormat: 'dd M' });

        });


        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))

                return false;
            return true;
        }

        function isNumberKeyFloat(evt, val) {
            //debugger;
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            else {
                var len = val.value.length;
                var index = val.value.indexOf('.');

                if (index > 0 && charCode == 46) {
                    return false;
                }
                if (index > 0) {
                    var CharAfterdot = (len + 1) - index;
                    if (CharAfterdot > 3) {
                        return false;
                    }
                }
            }
            return true;
        }


        var serviceUrl = '<%= ResolveUrl("~/Webservices/iKandiService.asmx/") %>';
        var proxy = new ServiceProxy(serviceUrl);

        function ChangedValue(ctrl, flag) {
            //debugger;
            var flag = flag;
            var value = ctrl.value;
            if (value != "") {
                var Quantity = $("#txtCMTQuantity").val();
                var SAM1 = $("#lblCMTSAM").text();
                var OB = $("#txtCMTOB").val();
                var Eff = $("#txtCMTEff").val();
                var StartDate = $("#txtCMTStartDate").val();

                proxy.invoke("GetCMTCalcualtor", { Quantity: Quantity, SAM1: SAM1, OB: OB, Eff: Eff, StartDate: StartDate, flag:flag },
           function (result) {

               $("#lblCMTEndDate").text(result[0]);
               $("#txtCMTEff").val(result[1]);
               $("#lblCMTPcsPerHour").text(result[2]);
               $("#lblCMTNoOfDays").text(result[3]);
               $("#lblCMTPcsPerDay").text(result[4]);
               if (result[5] != "0") {
                   $("#lblCMTHolidays").text(result[5]);
               }


           },
           onPageError, false, false);
            }
            else {
                alert("Can not be blank");

            }

        }
        
    </script>
    <script>
        $(document).ready(function () {
            $("#txtCMTStartDate").datepicker();
        });
    </script>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 100%; margin-bottom: 7px;" cellpadding="0" cellspacing="0" border="0"
            class="AddClass_Table">
            <tr style="text-align: center">
                <th colspan="2" style="font-size: 16px; color: #000; text-align: center">
                    Production End Date Planner
                </th>
            </tr>
            <tr>
                <th style="width: 150px" align="center">
                    Quantity
                </th>
                <td>
                    <asp:TextBox ID="txtCMTQuantity" runat="server" onchange="ChangedValue(this,'Quantity')" onkeypress="return isNumberKey(event, this)"
                        ForeColor="#0000ee"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    SAM
                </th>
                <td style="padding-left: 8px">
                    <%--<asp:TextBox ID="txtCMTSAM" runat="server"  ForeColor="#6b6464" disabled></asp:TextBox>--%>
                    <asp:Label ID="lblCMTSAM" ForeColor="#000" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    OB
                </th>
                <td>
                    <asp:TextBox ID="txtCMTOB" runat="server" onchange="ChangedValue(this,'')" onkeypress="return isNumberKey(event, this)"
                        ForeColor="#0000ee"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Efficiency %
                </th>
                <td>
                    <asp:TextBox ID="txtCMTEff" runat="server" onchange="ChangedValue(this,'')" onkeypress="return isNumberKey(event, this)"
                        ForeColor="#0000ee"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Pcs. Per Hour
                </th>
                <td style="padding-left: 8px">
                    <%--<asp:TextBox ID="txtCMTPcsPerHour" runat="server"  ForeColor="#6b6464" ReadOnly></asp:TextBox>--%>
                    <asp:Label ID="lblCMTPcsPerHour" ForeColor="#000" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Pcs. Per Day
                </th>
                <td style="padding-left: 8px">
                    <%-- <asp:TextBox ID="txtCMTPcsPerDay" runat="server"  ForeColor="#6b6464" ReadOnly></asp:TextBox>--%>
                    <asp:Label ID="lblCMTPcsPerDay" ForeColor="#000" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    No. of Days
                </th>
                <td style="padding-left: 8px">
                    <%-- <asp:TextBox ID="txtCMTNoOfDays" runat="server" ForeColor="#6b6464" ReadOnly></asp:TextBox>--%>
                    <asp:Label ID="lblCMTNoOfDays" runat="server" ForeColor="#000"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Start Date
                </th>
                <td>
                    <asp:TextBox ID="txtCMTStartDate" runat="server" CssClass="CMTCalender" onchange="ChangedValue(this,'')"
                        ForeColor="#0000ee"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Holidays
                </th>
                <td style="padding-left: 8px">
                    <%--  <asp:TextBox ID="txtCMTHolidays" runat="server"  ForeColor="#6b6464" ReadOnly></asp:TextBox>--%>
                    <asp:Label ID="lblCMTHolidays" ForeColor="#000" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    End Date
                </th>
                <td style="padding-left: 8px">
                    <%-- <asp:TextBox ID="txtCMTEndDate" runat="server" ForeColor="#000" ReadOnly style="font-weight:600"></asp:TextBox>--%>
                    <asp:Label ID="lblCMTEndDate" runat="server" Font-Bold="true" ForeColor="#000"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnResetCMT" CssClass="btnbutton_Com" runat="server" Text="Reset" style="padding:2px 10px;margin-right: 4px;"
            OnClick="btnResetCMT_Click" />
        <asp:Button ID="btnClose" CssClass="btnbutton_Com" BackColor="Red" BorderColor="Red"
            runat="server" Text="Close" style="padding:2px 10px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
    </div>
    </form>
</body>
</html> 