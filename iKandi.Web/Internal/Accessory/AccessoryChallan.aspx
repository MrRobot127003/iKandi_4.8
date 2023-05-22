<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessoryChallan.aspx.cs"
    Inherits="iKandi.Web.Internal.Accessory.AccessoryChallan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        input
        {
            border-radius: 2px;
            border: 1px solid #999;
            padding-left: 3px !important;
        }
        body
        {
            font-family: Arial !important;
        }
        .debitnote-table
        {
            font-family: Arial !important;
        }
        .debitnote-table .top_heading
        {
            text-transform: capitalize;
            font-size: 15px;
            font-weight: 500;
            padding-top: 3px;
            text-align: center;
            padding-bottom: 5px;
            background: #39589c;
            color: #fff;
        }
        .debitnote-table .address_head
        {
            font-weight: 500;
            font-size: 11px;
            line-height: 15px;
        }
        .debitnote-table .Srnon
        {
            font-weight: 600;
            font-size: 18px;
        }
        tbody td
        {
            padding: 3px 3px;
            font-size: 11px; /* text-transform: uppercase; */
        }
        tbody td.borderbottom
        {
            border-bottom: 1px solid #9999;
            border-left: 1px solid #9999;
            padding: 2px 3px;
            font-size: 11px;
            width: 150px;
            border-collapse: collapse;
        }
        .formcontrol
        {
            width: 98%;
        }
        .formcontrol2
        {
            width: 99%;
        }
        .headerbold
        {
            font-weight: 600;
        }
        ul
        {
            margin: 0;
            padding: 0px 0px;
            max-width: 100%;
            list-style-type: none;
        }
        li
        {
            float: left;
            line-height: 16px;
            padding: 0px;
        }
        .tablewidth
        {
            width: 350px;
            padding: 0px 3px 5px;
            border-bottom: 1px solid #9999;
        }
        .tableto
        {
            width: 80px;
        }
        .bottomborder
        {
            border-bottom: 1px solid #9999;
            padding: 10px 5px;
        }
        .listwidth
        {
            width: 80px;
        }
        tbody td.bordertable
        {
            border-bottom: 1px solid #9999;
            border-left: 1px solid #9999;
            padding: 2px 3px;
            font-size: 11px;
            border-collapse: collapse;
            text-align: center;
        }
        .metercol
        {
            width: 50px;
        }
        .cmcoloum
        {
            width: 40px;
        }
        .checkboxtop
        {
            position: relative;
            top: 2px;
        }
        input
        {
            padding: 0px 3px;
        }
        .textaria
        {
            width: 82%;
        }
        .inputfield
        {
            width: 95%;
        }
        .bottomborder1
        {
            border-bottom: 1px solid #9999;
            text-align: center;
        }
        .rightborder
        {
            border-right: 1px solid #9999;
        }
        .btnbutton
        {
            background: #1976D2;
            color: #fff;
            border: 1px solid #1976d2;
            padding: 4px;
            border-radius: 3px;
        }
        .headerbacground
        {
            background: #e4e2e2;
            font-size: 11px;
            height: 20px;
            font-weight: 500;
            color: #6b6464;
        }
        
        .p-r-5
        {
            padding-right: 5px;
        }
        .textcenter
        {
            text-align: center;
            font-size: 11px;
        }
        
        
        select
        {
            font-size: 11px;
        }
        input
        {
            font-size: 11px;
        }
        .borderleft
        {
            border-left: 1px solid #9999;
        }
        .borderleft0bottom
        {
            border-bottom: 1px solid #9999;
        }
        .metersr tbody td
        {
            height: 13px;
        }
        .meterQury thead th
        {
            border: 1px solid #999;
            text-align: center;
            font-weight: 500;
        }
        /* .meterQury tbody td
        {
            border:1px solid #9999;
            text-align:center;
        }*/
        .tabletdhei
        {
            height: 16px !important;
        }
        .btnSubmit
        {
            margin-left: 10px;
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .btnSubmit:hover
        {
            color: Yellow !important;
        }
        .btnClose
        {
            margin-left: 10px;
            color: rgb(255, 255, 255);
            font-size: 12px !important;
            float: left;
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: rgb(19, 167, 71);
            height: 24px;
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .btnClose:hover
        {
            color: red;
        }
        .btnPrint
        {
            margin-left: 10px;
            font-size: 12px !important;
            float: left;
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 52px;
            cursor: pointer;
            background: #39589c !important;
            height: 24px;
            line-height: 24px;
            border: none !important;
            border-radius: 2px;
        }
        .btnPrint:hover
        {
            color: Yellow !important;
        }
        #grdChallan1
        {
            border-collapse: collapse;
            border-top: 0px;
            width: 34%;
            float: left;
            border-top: 1px solid #999;
            border-bottom: 1px solid #999;
            border-right: 1px solid #999;
        }
        #grdChallan1 th
        {
            border: 1px solid #999;
            background: #e4e2e2;
            font-size: 11px;
            font-weight: 500;
            color: #6b6464;
        }
        #grdChallan2 th
        {
            border: 1px solid #999;
            background: #e4e2e2;
            font-size: 11px;
            font-weight: 500;
            color: #6b6464;
        }
        #grdChallan1 td
        {
            border: 1px solid #9999;
            text-align: center;
            padding: 1px 3px;
        }
        #grdChallan2
        {
            border-collapse: collapse;
            width: 24%;
            border-top: 1px solid #999;
            border-right: 1px solid #999;
            border-bottom: 1px solid #999;
        }
        #challanTable2 th
        {
            border: 1px solid #999;
            background: #e4e2e2;
            font-size: 11px;
            height: 20px;
            font-weight: 500;
            color: #6b6464;
        }
        #grdChallan2 td
        {
            border: 1px solid #9999;
            text-align: center;
            padding: 1px 3px;
        }
        .ChallanTable1
        {
            width: 24% !important;
        }
        .TableWidthCha1
        {
            width: 52% !important;
        }
        .FrstHeader
        {
            width: 23% !important;
        }
        .LasttHeader
        {
            width: 21% !important;
        }
        .ChallanTable1Header
        {
            width: 48% !important;
        }
        .txtEditWidth
        {
            text-align: center;
        }
        td #chkProcess td
        {
            padding: 0px 3px !important;
        }
        #grdChallan1 tr:nth-last-child(1) td
        {
            border-bottom-color: #999 !important;
        }
        #grdChallan2 tr:nth-last-child(1) td
        {
            border-bottom-color: #999 !important;
        }
        #grdChallan1 td:last-child
        {
            border-right-color: #999 !important;
        }
        #grdChallan2 td:last-child
        {
            border-right-color: #999 !important;
        }
        input[type='text']
        {
            padding-left: 3px;
        }
        .spanHdrColor
        {
            color: Gray;
        }
        #chkProcess input[type="checkbox"]
        {
            position:relative;
            top:2px;
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/jquery.jcarousel.js")%>'></script>
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
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/date.js")%>'></script>
    <script type="text/javascript">
        var txtPcsClientID = '<%=txtPcs.ClientID %>';
        var hdnRowCountClientID = '<%=hdnRowCount.ClientID %>';
        var hdnTotalPcsClientID = '<%=hdnTotalPcs.ClientID %>';
        var txtTotalUnitClientID = '<%=txtTotalUnit.ClientID %>';
        var txtTotalPcsClientID = '<%=txtTotalPcs.ClientID %>';
        var lblTotalPcs_ClientID = '<%=lblTotalPcs.ClientID %>';
        var hdnAvailableQtyClientId = '<%=hdnAvailableQty.ClientID %>';
        var lblAvailableQtyClientID = '<%=lblAvailableQty.ClientID %>';
        var lblAvailableQtyUnit_ClientID = '<%=lblAvailableQtyUnit.ClientID %>';



        function ValidateUnit() {
            //debugger;           
            var AvailableQty = $("#" + hdnAvailableQtyClientId).val();
            var Pcs = $("#" + txtPcsClientID).val();
            if (Pcs == '')
                Pcs = '0';
            if (Pcs == '0') {
                alert('Qty can not be 0 or Empty');
                $("#" + txtPcsClientID).val('');
                return false;
            }
            var TotalQty = 0;

            var GridRow1 = $(".gvRow1").length;

            var RowId = 0;
            gvId = '';
            for (var row = 1; row <= GridRow1; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var txtQty = $("#<%= grdChallan1.ClientID %> input[id*='" + gvId + "_txtQty" + "']").val();
                if ((txtQty == '') || (txtQty == '0')) {
                    alert('Qty can not be 0 or Empty');
                    $("#<%= grdChallan1.ClientID %> input[id*='" + gvId + "_txtQty" + "']").focus();
                    return false;
                }
                TotalQty = parseInt(TotalQty) + parseInt(txtQty);
            }

            var GridRow2 = $(".gvRow2").length;
            if (parseInt(GridRow2) > 0) {

                for (var row = 1; row <= GridRow2; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var txtQty = $("#<%= grdChallan2.ClientID %> input[id*='" + gvId + "_txtQty" + "']").val();
                    if ((txtQty == '') || (txtQty == '0')) {
                        alert('Qty can not be 0 or Empty');
                        $("#<%= grdChallan2.ClientID %> input[id*='" + gvId + "_txtQty" + "']").focus();
                        return false;
                    }

                    TotalQty = parseInt(TotalQty) + parseInt(txtQty);
                }
            }
            TotalQty = parseInt(TotalQty) + parseInt(Pcs);

            if (parseInt(TotalQty) > parseInt(AvailableQty)) {
                alert("Unit Qty cannot greater than Available Quantity!");
                $("#" + txtPcsClientID).val('');
                return false;
            }
        }

        function ValidateSubmit() {
            // debugger;
            var ddlType = $("#ddlType").val();
            var ProDucUnit = $("#ddlProductionUnit").val();
            if ((ddlType == "2") && (ProDucUnit == "-1")) {
                alert("Please Select Production Unit!");
                return false;
            }
            var cnt = $("#chkProcess input:checked").length;
            if (cnt < 1) {
                alert('Please Select at least one Process');
                return false;
            }
            var AvailableQty = $("#" + hdnAvailableQtyClientId).val();

            var TotalQty = 0;

            var GridRow1 = $(".gvRow1").length;
            if (parseInt(GridRow1) < 1) {
                alert('Please add Unit');
                $("#" + txtPcsClientID).focus();
                return false;
            }
            var RowId = 0;
            gvId = '';
            for (var row = 1; row <= GridRow1; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                var txtQty = $("#<%= grdChallan1.ClientID %> input[id*='" + gvId + "_txtQty" + "']").val();
                if ((txtQty == '') || (txtQty == '0')) {
                    alert('Qty can not be 0 or Empty');
                    $("#<%= grdChallan1.ClientID %> input[id*='" + gvId + "_txtQty" + "']").focus();
                    return false;
                }
                TotalQty = parseInt(TotalQty) + parseInt(txtQty);
            }

            var GridRow2 = $(".gvRow2").length;
            if (parseInt(GridRow2) > 0) {

                for (var row = 1; row <= GridRow2; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    var txtQty = $("#<%= grdChallan2.ClientID %> input[id*='" + gvId + "_txtQty" + "']").val();
                    if ((txtQty == '') || (txtQty == '0')) {
                        alert('Qty can not be 0 or Empty');
                        $("#<%= grdChallan2.ClientID %> input[id*='" + gvId + "_txtQty" + "']").focus();
                        return false;
                    }

                    TotalQty = parseInt(TotalQty) + parseInt(txtQty);
                }
            }
            if (parseInt(TotalQty) > parseInt(AvailableQty)) {
                alert("No. of Pcs. cannot greater than Available Quantity!");
                return false;
            }
        }

        function closePage() {
            //            alert('Saved Successfully!');

            self.parent.parent.PageReload();
            self.parent.Shadowbox.close()
        }
        function pageLoad() {

            var POMinDate = new Date().addDays(-30);
            var POMaxDate = new Date().addDays(30);
            $(".PODate").datepicker({ dateFormat: "dd M y (D)", minDate: POMinDate, maxDate: POMaxDate }).val();

            $('#challanTable2').hide();
            var GridRow = $(".gvRow2").length;
            // alert(GridRow);
            if (GridRow > 0) {
                /// alert(GridRow);
                $('#challanTable2').show();
                $('.TableWidthCha').addClass('TableWidthCha1');
                $('#grdChallan1').addClass('ChallanTable1');
                $('.meterQury').addClass('ChallanTable1Header');
                $('.FirstColWidth').addClass('FrstHeader');
                $('.LastColWidth').addClass('LasttHeader');
            }

        }

        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57 || iKeyCode == 46))
                return false;

            return true;
        }
        function disablePage() {
            for (var i = 0; i < document.forms[0].elements.length; i++) {
                document.forms[0].elements[i].disabled = true;
            }
            $("#imgbtnAdd").hide();
            //debugger;
            var GridRow1 = $(".gvRow1").length;
            var RowId = 0;
            gvId = '';
            for (var row = 1; row <= GridRow1; row++) {
                RowId = parseInt(row) + 1;
                if (RowId < 10)
                    gvId = 'ctl0' + RowId;
                else
                    gvId = 'ctl' + RowId;

                $("#<%= grdChallan1.ClientID %> a[id*='" + gvId + "_lnkDelete" + "']").hide();

            }

            var GridRow2 = $(".gvRow2").length;
            if (parseInt(GridRow2) > 0) {

                for (var row = 1; row <= GridRow2; row++) {
                    RowId = parseInt(row) + 1;
                    if (RowId < 10)
                        gvId = 'ctl0' + RowId;
                    else
                        gvId = 'ctl' + RowId;

                    $("#<%= grdChallan2.ClientID %> a[id*='" + gvId + "_lnkDelete" + "']").hide();

                }
            }
        }

        function CheckQty(obj) {
            //debugger;
            if ($(obj).is(':checked')) {
                var AvailableQty = $("#" + lblAvailableQtyClientID).text();
                if ((AvailableQty != '') && (AvailableQty != '0')) {
                    if (!confirm(AvailableQty + ' Qty remaining! Are you sure, want to close it!')) {
                        //debugger;
                        $(obj).removeAttr("checked");
                    }
                }
            }
        }
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="debitnote-table" style="max-width: 99.8%; margin: 0px auto; border: 0px solid #999;">
                <table cellpadding="0" cellspacing="0" style="max-width: 100%; width: 100%; border: none;
                    border: 1px solid #999999; border-bottom: 0px;">
                    <thead>
                        <tr>
                            <td style="border-bottom: 1px solid #999999;">
                            </td>
                            <td class="top_heading texttranceform bottomborder1" colspan="">
                                Accessory challan
                            </td>
                        </tr>
                    </thead>
                </table>
                <table class="TableWidthCha" style="max-width: 100%; width: 66%; border: none; margin-bottom: 15px;
                    border: 1px solid #999999; border-top: 0px; float: left" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td style="vertical-align: top; width: 125px; border-bottom: 1px solid #9999"" colspan='2'>
                                <div style="padding: 9px 7px; width: 125px; float: left">
                                    <img src="../../images/boutique-logo.png" />
                                </div>
                                <div id="divbipladdress" runat="server">
                                </div>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id="trPO" runat="server">
                            <td class=" texttranceform borderleft0bottom" colspan='2' style="height: 13px;">
                                <div class="spanHdrColor" style="width: 38px; display: inline-block;">
                                    PO No:</div>
                                <asp:TextBox ID="txtPoNo" Style="border: 0px;" CssClass="do-not-allow-typing" Width="30%"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class=" texttranceform borderleft0bottom" colspan='2' style="height: 13px">
                                <div class="spanHdrColor" style="width: 72px; display: inline-block;">
                                    Challan No:</div>
                                <asp:Label ID="lblChallan" Font-Bold="true" runat="server" Text=""></asp:Label>
                               <%-- <asp:TextBox ID="txtChallan" Width="37%" CssClass="do-not-allow-typing" runat="server"></asp:TextBox>--%>
                            </td>
                            <asp:HiddenField ID="hdnChallan" runat="server" />
                            <asp:HiddenField ID="hdnAccessoryMasterId" runat="server" />
                        </tr>
                        <tr>
                         
                            <td class=" texttranceform borderleft0bottom" colspan='2'>
                                <div class="spanHdrColor" style="width: 72px; display: inline-block;">
                                    Date:
                                </div>
                                <asp:TextBox ID="txtChallanDate" Width="88px" runat="server" CssClass="do-not-allow-typing PODate"
                                    Style="text-transform: capitalize;border:0px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                         <td class="borderleft0bottom" style="width:90px"> Select </td>
                            <td class=" texttranceform borderleft0bottom" style="height: 44px;">
                                <asp:CheckBoxList ID="chkProcess" RepeatDirection="Horizontal" RepeatColumns="3"
                                    runat="server">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="borderleft0bottom spanHdrColor">
                                To: &nbsp;
                                <asp:DropDownList ID="ddlType" runat="server">
                                    <asp:ListItem Value="1" Text="External"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Internal"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 258px;" class="borderleft0bottom">
                                <div id="dvUnit" runat="server">
                                    <span style="color: Red; font-size: 12px;">*</span><span class="spanHdrColor"> M/S:</span>
                                    <asp:DropDownList ID="ddlProductionUnit" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvStyle" runat="server">
                                    <span class="spanHdrColor" style="display: inline-block; width: 130px">Style No: &nbsp;
                                        <asp:Label ID="lblStyleNo" ForeColor="Black" runat="server"></asp:Label>
                                    </span><span class="spanHdrColor">Serial No: &nbsp;
                                        <asp:Label ID="lblSerialNo" ForeColor="Black" runat="server"></asp:Label>
                                    </span>
                                </div>
                                <div id="dvSupplier" class="spanHdrColor" runat="server">
                                    Supplier Name: &nbsp; <b>
                                        <asp:Label ID="lblSupplierName" ForeColor="Black" runat="server"></asp:Label></b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="bottomborder1 spanHdrColor" style="text-align: left">
                                Accessory (Size)/Color Print:<span>&nbsp;&nbsp;
                                    <asp:Label ID="lblAccessoryQuality" ForeColor="Blue" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblSize" ForeColor="Gray" Text="" runat="server"></asp:Label>
                                    <asp:Label ID="lblcolorprint" Height="15px" Font-Bold="true" ForeColor="Black" Text=""
                                        runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="spanHdrColor">
                                Description <span>
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="98%" runat="server"
                                        Style="margin-top: 1px; text-transform: lowercase;"></asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table class="meterQury" runat="server" id="tblUnit" border="1" style="max-width: 100%;
                    width: 34%; margin-bottom: 2px; border-collapse: collapse; border-left: 0px;
                    border-color: #ece9e999">
                    <thead>
                        <tr>
                            <th style="border-left: 0px">
                                <asp:TextBox ID="txtPcs" runat="server" Width="44%" placeholder="Unit" Style="text-transform: capitalize;
                                    padding-left: 3px; height: 14px;" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                <asp:Label ID="lblGarmentUnit" Font-Bold="true" ForeColor="Gray" runat="server" Text=""></asp:Label>
                            </th>
                            <th>
                                <asp:ImageButton ID="imgbtnAdd" OnClientClick="javascript:return ValidateUnit()"
                                    ImageUrl="~/images/add-butt.png" runat="server" OnClick="imgbtnAdd_Click" />
                            </th>
                        </tr>
                    </thead>
                </table>
                <asp:GridView ID="grdChallan1" ShowHeader="true" runat="server" PageSize="16" CssClass="grdviewtable"
                    AutoGenerateColumns="false" BorderWidth="0" OnRowDeleting="grdChallan1_RowDeleting"
                    OnRowDataBound="grdChallan1_RowDataBound">
                    <RowStyle CssClass="gvRow1" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                <asp:HiddenField ID="hdnBreakDownId" Value='<%# Eval("Challan_BreakDown_Id") %>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnId" Value='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="18%" CssClass="border_left FirstColWidth" />
                            <HeaderStyle Width="18%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" MaxLength="4" Width="40px" CssClass="txtEditWidth" onkeypress="return isNumberKey(event)"
                                    Text='<%# Eval("Pcs") %>' runat="server"></asp:TextBox>
                                <asp:Label ID="lblGroupUnit" Style="text-transform: capitalize; color: Gray; font-weight: bold;"
                                    runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" style="width: 14px;" /> </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="18%" CssClass="border_right LastColWidth" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="grdChallan2" ShowHeader="true" runat="server" PageSize="16" CssClass="grdviewtable"
                    AutoGenerateColumns="false" BorderWidth="0" OnRowDeleting="grdChallan2_RowDeleting"
                    OnRowDataBound="grdChallan2_RowDataBound">
                    <RowStyle CssClass="gvRow2" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No.">
                            <ItemTemplate>
                                <%# Eval("RowNo")%>
                                <asp:HiddenField ID="hdnBreakDownId" Value='<%# Eval("Challan_BreakDown_Id") %>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnId" Value='<%# Eval("RowNo")%>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="23%" CssClass="border_left" />
                            <HeaderStyle Width="23%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" MaxLength="4" Width="40px" CssClass="txtEditWidth" onkeypress="return isNumberKey(event)"
                                    Text='<%# Eval("Pcs") %>' runat="server"></asp:TextBox>
                                <asp:Label ID="lblGroupUnit" Style="text-transform: capitalize; color: gray" runat="server"
                                    Font-Bold="true" Text=""></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ForeColor="black" Width="30px" ID="lnkDelete" runat="server" CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete?')"> <img src="../../images/del-butt.png" style="width:14px;" /> </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="18%" CssClass="border_right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table style="max-width: 100%; width: 100%; padding-bottom: 0px; border: none; margin-bottom: 10px;
                    border: 1px solid #999999; border-top: 1px solid #999999" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="rightborder spanHdrColor">
                                Total Unit
                            </td>
                            <td class="rightborder spanHdrColor" style="">
                                <asp:TextBox ID="txtTotalUnit" ReadOnly="true" ForeColor="Gray" Font-Bold="true"
                                    Width="80px" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdnRowCount" Value="0" runat="server" />
                                <span style="color: gray">Rolls/Boxes</span>
                            </td>
                            <td class="rightborder spanHdrColor">
                                No. of Pieces
                                <asp:TextBox ID="txtTotalPcs" ReadOnly="true" Width="80px" runat="server"></asp:TextBox>
                                <asp:Label ID="lblTotalPcs" Style="text-transform: capitalize; color: gray; font-weight: bold;"
                                    runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnTotalPcs" Value="0" runat="server" />
                                <asp:HiddenField ID="hdnTotalPcsOnPageLoad" runat="server" />
                            </td>
                            <td class="rightborder spanHdrColor" style="">
                                Available Qty.
                                <asp:Label ID="lblAvailableQty" Width="30px" runat="server"></asp:Label>
                                <asp:Label ID="lblAvailableQtyUnit" Style="text-transform: capitalize; color: gray;
                                    font-weight: bold;" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnAvailableQty" Value="0" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table class="MarginTop8" style="max-width: 100%; margin-bottom: 10px; font-size: 12px;
                    width: 100%; margin-top: 12px; border: none; border-top: 1px solid #999;" cellspacing="0"
                    cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="" style="padding: 5px 0px 5px 10px; width: 60%;" class="headerbold">
                                Received the goods in good condition
                            </td>
                            <td style="padding: 5px 10px 5px; text-align: right" colspan="">
                                <span class="texttranceform"><b>Boutique International Pvt. Ltd.</b></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="" class="PaddingTop0 headerbold" style="padding-top: 0px; padding-left: 12px;
                                font-size: 11px; color: #6b6464">
                                <div runat="server" id="divChkReceive">
                                    <asp:CheckBox ID="chkrecivegood" runat="server" />
                                    (Receiver's Signature)
                                </div>
                                <div runat="server" id="divSigReceive" visible="false">
                                    <asp:Image ID="imgReceiver" runat="server" Height="40px" Width="130px" />
                                    <br />
                                    <asp:Label ID="lblReceiverName" runat="server" Style="line-height: 20px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblReceivedOnDate" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td class="PaddingTop0 headerbold signauth" style="float: right; padding-top: 0px;
                                padding-right: 15px; font-size: 11px; color: #6b6464">
                                <div runat="server" id="divChkAuthorized">
                                    <asp:CheckBox ID="chkAuthorised" runat="server" />
                                    (Authorized Signature)
                                </div>
                                <div runat="server" id="divSigAuthorized" visible="false">
                                    <asp:Image ID="imgAuthorized" runat="server" Height="40px" Width="130px" />
                                    <br />
                                    <asp:Label ID="lblAuthorizedName" runat="server" Style="line-height: 20px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblAuthorizedOnDate" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </thead>
                </table>
                <table style="max-width: 100%; width: 100%; padding-bottom: 0px; border: none; margin-bottom: 10px;
                    border: 0px solid #999999; border-top: 0px solid #999999" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="5" style="text-align: center; padding-top: 5px;">
                            <div class="form_buttom" style="float: left;">
                                <asp:Button ID="btnSubmit" CssClass="btnSubmit printHideButton" OnClientClick="javascript:return ValidateSubmit()"
                                    runat="server" Text="Save" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="btnClose printHideButton" id="Closesbox" onclick="javascript:self.parent.Shadowbox.close();">
                                Close</div>
                            <div class="btnPrint printHideButton" onclick="window.print();return false">
                                Print</div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
