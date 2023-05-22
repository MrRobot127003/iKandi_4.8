<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitsEtaPopup.aspx.cs" Inherits="iKandi.Web.Admin.FitsSample.FitsEtaPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .item_list2 TH
        {
            color: #98a9ca;
            font-size: 8px;
            line-height: 15px;
            vertical-align: top;
            background-color: #39589c !important;
            text-transform: capitalize;
            border: 1px solid #e6e6e6;
            text-align: center;
            padding: 4px;
            font-weight: normal;
        }
        .ui-widget-content
        {
            border: 0px !important;
            padding: 0px !important;
        }
        .item_list2 td:first-child
        {
            border-left-color: #999 !important;
        }
        .item_list2 td:last-child
        {
            border-right-color: #999 !important;
        }
        .item_list2 tr:last-child > td
        {
            border-bottom-color: #999 !important;
        }
    </style>
    <link href="../../css/jquery-combined.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery-combined.css" />
    <link href="../../css/technical-module.css" rel="stylesheet" type="text/css" />
    <%-- <script src="../../js/jquery-1.11.0.min.js" type="text/javascript"></script>--%>
    <script src="../../CommonJquery/JqueryLibrary/jquery-ui-1.10.2.custom.js" type="text/javascript"></script>
    <script type="text/javascript">


        $(function () {
            //debugger;
            $('input.do-not-allow-typing, textarea.do-not-allow-typing').keydown(function () { return false; });
            $(".th").datepicker({ dateFormat: 'dd M y (D)' });


        });

        function UpdatePatternSampleDateForMO(elem, txtname) {

            debugger;
            var Ids = elem.id;
            var patternSampleDate = elem.value;
            var CId = Ids.split("_")[1].substr(3);
            var styleid = document.getElementById("GridView1_ctl" + CId + "_hdnStyleID").value;
            var orderid = document.getElementById("GridView1_ctl" + CId + "_hdnOrderId").value;


            //        proxy.invoke("UpdatePatternSampleDate", { OrderID: orderid, StyleId: styleid, PatternSampleDate: patternSampleDate, field: txtname }, function (result) {

            //            $(".loadingimage").hide();

            //            //jQuery.facebox(result);

            //            // DoForcePostBack();

            //            if (txtname == 'stc')

            //            { jQuery.facebox('STC Requested Data has been saved successfully!'); }

            //            else {

            //                jQuery.facebox('Pattern Sample Data has been saved successfully!');

            //            }

            //        }, onPageError, false, false);

            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdatePatternSampleDate",
                data: "{ OrderID:'" + orderid + "', StyleId:'" + styleid + "', PatternSampleDate:'" + patternSampleDate + "', field:'" + txtname + "', OrderDetailID:'" + 0 + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });
            function OnSuccessCall(response) {
                //debugger
                if (txtname == 'Pattern')

                { alert('Pattern Sample date has been saved successfully!'); }
                if (txtname == 'Cutting')

                { alert('Cutting Sheet Received Data has been saved successfully!'); }

                else if (txtname == 'Production') {

                    alert('Production Data has been saved successfully!');
                }

                else if (txtname == 'CuttingETA') {

                    alert('Cutting ETA Data has been saved successfully!');

                }
                else if (txtname == 'HPPPMETA') {

                    alert('HPPPM ETA Data has been saved successfully!');

                }

                else if (txtname == 'ProductionETA') {

                    alert('Production ETA Data has been saved successfully!');

                }
                else if (txtname == 'TESTREPORTS') {

                    alert('Test Report ETA Data has been saved successfully!');

                }
                else if (txtname == 'CDChartETA') {

                    alert('CD chart ETA Data has been saved successfully!');

                }
                else if (txtname == 'CDChartActual') {

                    alert('CD chart Actual ETA Data has been saved successfully!');

                }
                else if (txtname == 'ICCHECK') {

                    alert('IC check saved successfully!');

                }
                else if (txtname == 'StrikeOff1') {

                    alert('Strike of for first fabric saved successfully!');

                }
                else if (txtname == 'StrikeOff2') {

                    alert('Strike of for Second fabric saved successfully!');

                }
                else if (txtname == 'StrikeOff3') {

                    alert('Strike of for Third fabric saved successfully!');

                }
                else if (txtname == 'StrikeOff4') {

                    alert('Strike of for Fourth fabric saved successfully!');

                }
                else if (txtname == 'HandOver') {

                    alert('HandOver saved successfully!');

                }
                else if (txtname == 'PatternReady') {

                    alert('PatternReady saved successfully!');

                }
                else if (txtname == 'SampleSent') {

                    alert('SampleSent saved successfully!');

                }
                else if (txtname == 'FitsUploadCommentes') {

                    alert('FitsUploadCommentes saved successfully!');

                }
            }
            function OnErrorCall(response) {
                //debugger
                alert(response.status + " " + response.statusText);
            }

        }
        function UpdateCuttingSheetDateForMO(elem, txtname) {
            debugger;
            var Ids = elem.id;

            var cuttingSheetDate = elem.value;
            var CId = Ids.split("_")[1].substr(3);
            var styleid = document.getElementById("GridView1_ctl" + CId + "_hdnStyleID").value;
            var orderid = document.getElementById("GridView1_ctl" + CId + "_hdnOrderId").value;
            var orderDetailsID = document.getElementById("GridView1_ctl" + CId + "_hdnOrderDetailsID").value;


            var url = "../../Webservices/iKandiService.asmx";
            $.ajax({
                type: "POST",
                url: url + "/UpdateCuttingSheetDate",
                data: "{ OrderID:'" + orderid + "', StyleId:'" + styleid + "', CuttingSheetDate:'" + cuttingSheetDate + "', orderDetails_ID:'" + orderDetailsID + "', field:'" + txtname + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessCall,
                error: OnErrorCall
            });
            function OnSuccessCall(response) {
                //debugger
                if (txtname == 'Cutting')

                { alert('Cutting Sheet Received Data has been saved successfully!'); }

                else if (txtname == 'Production') {

                    alert('Production Data has been saved successfully!');
                }

                else if (txtname == 'CuttingETA') {

                    alert('Cutting ETA Data has been saved successfully!');

                }
                else if (txtname == 'HPPPMETA') {

                    alert('HPPPM ETA Data has been saved successfully!');

                }

                else if (txtname == 'ProductionETA') {

                    alert('Production ETA Data has been saved successfully!');

                }
                else if (txtname == 'TESTREPORTS') {

                    alert('Test Report ETA Data has been saved successfully!');

                }
                else if (txtname == 'CDChartETA') {

                    alert('CD chart ETA Data has been saved successfully!');

                }
                else if (txtname == 'CDChartActual') {

                    alert('CD chart Actual ETA Data has been saved successfully!');

                }
                else if (txtname == 'ICCHECK') {

                    alert('IC check saved successfully!');

                }
                else if (txtname == 'StrikeOff1') {

                    alert('Strike of for first fabric saved successfully!');

                }
                else if (txtname == 'StrikeOff2') {

                    alert('Strike of for Second fabric saved successfully!');

                }
                else if (txtname == 'StrikeOff3') {

                    alert('Strike of for Third fabric saved successfully!');

                }
                else if (txtname == 'StrikeOff4') {

                    alert('Strike of for Fourth fabric saved successfully!');

                }
                else if (txtname == 'HandOver') {

                    alert('HandOver saved successfully!');

                }
                else if (txtname == 'PatternReady') {

                    alert('PatternReady saved successfully!');

                }
                else if (txtname == 'SampleSent') {

                    alert('SampleSent saved successfully!');

                }
                else if (txtname == 'FitsUploadCommentes') {

                    alert('FitsUploadCommentes saved successfully!');

                }
            }
            function OnErrorCall(response) {
                // debugger
                alert(response.status + " " + response.statusText);
            }
            //        proxy.invoke("UpdateCuttingSheetDate", { OrderID: orderid, StyleId: styleid, CuttingSheetDate: cuttingSheetDate, orderDetails_ID: orderDetailsID, field: txtname }, function (result) {

            //            $(".loadingimage").hide();

            // jQuery.facebox(result);

            //  DoForcePostBack();




            //jQuery.facebox('Cutting Sheet Received Data has been saved successfully!');

            //}, onPageError, false, false);



        }
        function showEtaPopup(Flag1, Flag2, StyleId, Val1, Val2, SDate, EDate, SerialNumber, Inhousepercent, OrderDetailId, IsWrite, ColumnId) {



            if (IsWrite != 'False') {
                if (SDate != "" && EDate != "" && Inhousepercent >= 100) {
                    alert("NO ENTRY REQUIRED AS ETA ALREADY FILLED")
                    return false;
                }
                else {
                    var url = '../../Internal/OrderProcessing/MOEtaPopup.aspx?Flag1=' + Flag1 + '&Flag2=' + Flag2 + '&StyleId=' + StyleId + '&Val1=' + Val1 + '&Val2=' + Val2 + '&SDate=' + SDate + '&EDate=' + EDate + '&SerialNumber=' + SerialNumber + '&OrderDetailId=' + OrderDetailId + '&ColumnId=' + ColumnId;
                    window.open(url, '_blank', 'height=525,width=1300,status=yes,toolbar=no,menubar=no,location=yes,scrollbars=yes,resizable=yes,screenx=0,screeny=0, addressbar=no, directories=no, titlebar=no');
                }
            }
            else {
                alert('You have not write permission')
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView CssClass="item_list2 persist-area" ID="GridView1" runat="server" AutoGenerateColumns="False"
            OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="10" ShowHeader="false"
            BorderWidth="0">
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="newcss2">
                    <ItemTemplate>
                        <div style="text-align: center; width: 100%; font-size: 8px; line-height: 10px; min-height: 215px;">
                            <table width="100%" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                                <tr>
                                    <th colspan="3" style="font-size: 12px;">
                                        Technical
                                    </th>
                                </tr>
                                <tr>
                                    <th rowspan="2">
                                        Status
                                    </th>
                                    <th>
                                        Target Date
                                    </th>
                                    <th rowspan="2">
                                        ETA
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        Actual Date
                                    </th>
                                </tr>
                                <tr id="apprHide" runat="server">
                                    <td id="tdPatternSample" runat="server" style="color: #807F80 !important; text-align: left;
                                        letter-spacing: -0.2px; line-height: 12px;">
                                        <asp:Label ID="lblPatternSampleName" runat="server" Text="Pattern Sample" Visible='<%# Eval("FitsPatternRead")%>'></asp:Label>
                                    </td>
                                    <td style="color: Black; text-align: center; width: 33%; padding: 0px !important;
                                        margin: 0px !important;">
                                        <asp:Label ID="lblpatterntar" Visible='<%# Eval("FitsPatternTargetDateRead")%>' ToolTip="Pattern Sample Target Date"
                                            CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                            runat="server" Text='<%# (Convert.ToDateTime(Eval("PatternSampleTarget")) == Convert.ToDateTime("01-01-0001")) ? "" : (Convert.ToDateTime(Eval("PatternSampleTarget"))).ToString("dd MMM")%>'></asp:Label>
                                        <asp:TextBox class="Pattern" ID="lblPatternSampleDate" Visible='<%# Eval("FitsPatternActualDateRead")%>'
                                            Enabled='<%# Eval("FitsPatternActualDateWrite")%>' onchange="javascript:return UpdatePatternSampleDateForMO(this,'Pattern');"
                                            Style="width: 98%; background-color: #F9F9FA !important;
                                            text-transform: capitalize !important; text-align: center; border: 0px; border-top: 1px solid #e6e6e6;"
                                            runat="server" CssClass="th" Text='<%# (Convert.ToDateTime(Eval("PatternSampleDate")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("PatternSampleDate")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDate")).ToString("dd MMM") %>'></asp:TextBox>
                                    </td>
                                    <td style='color: #00E; text-align: center; padding: 0px; <%# "background-color :" + Eval("FitsPatternETABackColor").ToString() %>'>
                                        <div>
                                            <asp:TextBox ID="PATTERNETA" runat="server" Height="20px" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsPatternETABackColor"))%>'
                                                ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsPatternETAForColor"))%>'
                                                Visible='<%# Eval("FitsPatternETARead")%>' Style="font-size: 8px; text-align: center;
                                                text-transform: capitalize; border: 0px;" CssClass="do-not-allow-typing" Width="98%"
                                                Text='<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM")%>'></asp:TextBox>
                                        </div>
                                        <span id="spanPatternpending" style="display: none;" runat="server"><a onclick="javascript:return showEtaPopup('PatternETA','FitsETA','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','','','<%# (Convert.ToDateTime(Eval("PatternSampleDateETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("PatternSampleDateETA")).ToString("dd MMM")%>','','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','','<%#Eval("OrderDetailID") %>',63);">
                                            <asp:TextBox ID="lblpatternpending" CssClass="do-not-allow-typing" Style="font-size: 8px !important;
                                                color: red !important; background-color: transparent;" runat="server" Width="70"
                                                Text='<%# Eval("Patternpending")%>'></asp:TextBox>
                                        </a></span>
                                    </td>
                                </tr>
                                <tr id="apprHide1" runat="server">
                                    <td id="tdCuttingSheet" runat="server" style="color: #807F80 !important; text-align: left;
                                        line-height: 12px;">
                                        <asp:Label ID="lblCuttingSheet" runat="server" Text="Cutting Sheet" Visible='<%# Eval("FitsCuttingkRead")%>'></asp:Label>
                                    </td>
                                    <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                        <asp:Label ID="lblcuttingtar" Visible='<%# Eval("FitsCuttingTargetDateRead")%>' ToolTip="Cutting Target Date"
                                            CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                            runat="server" Text='<%# (Convert.ToDateTime(Eval("CuttingTarget")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("CuttingTarget")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("CuttingTarget"))).ToString("dd MMM")%>'></asp:Label>
                                        <asp:TextBox ID="lblCuttingSheetDate" Visible='<%# Eval("FitsCuttingActualDateRead")%>'
                                            Enabled='<%# Eval("FitsCuttingActualDateWrite")%>' onchange="javascript:return UpdateCuttingSheetDateForMO(this,'Cutting');"
                                            Style="width: 98%; font-size: 8px !important; background-color: #F9F9FA !important;
                                            text-transform: capitalize !important; text-align: center; border: 0px; border-top: 1px solid #e6e6e6;"
                                            runat="server" CssClass="th" Text='<%# (Convert.ToDateTime(Eval("CuttingReceivedDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("CuttingReceivedDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CuttingReceivedDate")).ToString("dd MMM") %>'></asp:TextBox>
                                    </td>
                                    <td style='color: #00E; text-align: center; padding: 0px; <%# "background-color :" + Eval("FitsCuttingETABackColor").ToString() %>'>
                                        <asp:TextBox ID="TextBox1" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsCuttingETABackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsCuttingETAForColor"))%>'
                                            Width="98%" onchange="javascript:return UpdateCuttingSheetDateForMO(this,'CuttingETA');"
                                            Style="font-size: 8px !important; border: 0px; text-align: center; text-transform: capitalize !important;"
                                            runat="server" Height="20px" Text='<%# (Convert.ToDateTime(Eval("CuttingReceivedDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("CuttingReceivedDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("CuttingReceivedDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                        <asp:Label ID="lblcutpending" Visible='<%# Eval("FitsCuttingETARead")%>' Enabled='<%# Eval("FitsCuttingETAWrite")%>'
                                            onchange="javascript:return UpdateCuttingSheetDateForMO(this,'CuttingETA');"
                                            Style="font-size: 8px !important; display: none; color: red !important;" runat="server"
                                            Width="70" Text='<%# Eval("Cuttingpending")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr id="apprHide2" runat="server">
                                    <td id="tdProdFile" runat="server" style="color: #807F80 !important; text-align: left;
                                        line-height: 12px;">
                                        <asp:Label ID="lblProdFile" runat="server" Text="Prod File" Visible='<%# Eval("FitsProdFileRead")%>'></asp:Label>
                                    </td>
                                    <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                        <asp:Label ID="lblprodtar" Visible='<%# Eval("FitsProdTargetDateRead")%>' ToolTip="Prod File Target Date"
                                            CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                            runat="server" Text='<%# (Convert.ToDateTime(Eval("ProductionFileTarget")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("ProductionFileTarget"))).ToString("dd MMM")%>'></asp:Label>
                                        <asp:TextBox ID="lblProductionFileDate" Visible='<%# Eval("FitsProdActualDateRead")%>'
                                            Enabled='<%# Eval("FitsProdActualDateWrite")%>' onchange="javascript:return UpdateCuttingSheetDateForMO(this,'Production');"
                                            Style="width: 98%; font-size: 8px !important; background-color: #F9F9FA !important;
                                            text-transform: capitalize !important; text-align: center; border: 0px; border-top: 1px solid #e6e6e6;"
                                            runat="server" CssClass="th" Text='<%# (Convert.ToDateTime(Eval("ProductionFileDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("ProductionFileDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("ProductionFileDate")).ToString("dd MMM") %>'></asp:TextBox>
                                    </td>
                                    <td style='color: #00E; text-align: center; padding: 0px; <%# "background-color :" + Eval("FitsProdETABackColor").ToString() %>'>
                                        <asp:TextBox ID="TextBox2" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsProdETABackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsProdETAForColor"))%>'
                                            Width="98%" onchange="javascript:return UpdateCuttingSheetDateForMO(this,'ProductionETA');"
                                            Style="font-size: 8px !important; text-transform: capitalize !important; height: 20px;
                                            text-align: center; border: 0px;" runat="server" Text='<%# (Convert.ToDateTime(Eval("ProductionFileDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("ProductionFileDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("ProductionFileDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                        <asp:Label ID="lblprodfilepending" onchange="javascript:return UpdateCuttingSheetDateForMO(this,'ProductionETA');"
                                            Style="font-size: 8px !important; color: red !important; display: none;" runat="server"
                                            Width="70" Text='<%# Eval("prodfilepending")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr id="apprHide3" runat="server">
                                    <td id="tdHoPPM" runat="server" style="color: #807F80 !important; text-align: left;
                                        line-height: 12px;">
                                        <a title="HOPPM Form" style="text-decoration: none;" target="_blank" href='/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>&stylenumber=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString() %>&FitsStyle=<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>&ClientID=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>&DeptId=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID %>&OrderID=<%# (Eval("OrderID"))%>&showHOPPMFORM=Yes'>
                                            <asp:Label ID="lblHOPPM" runat="server" ToolTip="HOPPM Form" Text="HO PPM" Visible='<%# Eval("FitsHOPPMRead")%>'></asp:Label>
                                        </a>
                                    </td>
                                    <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                        <asp:Label ID="lblHOPPMTarget" Visible='<%# Eval("FitsHOPPMTargetDateRead")%>' ToolTip="HO PPM Target Date"
                                            CssClass="date_style  do-not-allow-typing" Style="font-size: 8px; font-weight: bold;"
                                            runat="server" Text='<%# (Convert.ToDateTime(Eval("HOPPMTargetETA")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("HOPPMTargetETA"))).ToString("dd MMM")%>'></asp:Label>
                                        <asp:Label ID="lblHOPPMActual" Visible='<%# Eval("FitsHOPPMActualDateRead")%>' Enabled='<%# Eval("FitsHOPPMActualDateWrite")%>'
                                            ToolTip="HO PPM Actual Date" Style="width: 98%; font-size: 8px !important; background-color: #F9F9FA !important;
                                            text-transform: capitalize !important;" Text='<%# (Convert.ToDateTime(Eval("HOPPMActionactualDate")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("HOPPMActionactualDate")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("HOPPMActionactualDate")).ToString("dd MMM") %>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style='color: #00E; text-align: center; padding: 0px !important; <%# "background-color :" + Eval("FitsHOPPMETABackColor").ToString() %>'>
                                        <span id="spanSTCAPPETA" runat="server">
                                            <asp:TextBox ID="txtETAHOPPM" Width="98%" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsHOPPMETABackColor"))%>'
                                                ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsHOPPMETAForColor"))%>'
                                                onchange="javascript:return UpdateCuttingSheetDateForMO(this,'HPPPMETA');" Style="font-size: 8px !important;
                                                height: 20px; text-align: center; border: 0px; text-transform: capitalize !important;"
                                                runat="server" Text='<%# (Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("HOPPMETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("HOPPMETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("HOPPMETA")).ToString("dd MMM") %>'></asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                                <tr id="apprHide4" runat="server">
                                    <td id="tdTopSent" runat="server" style="color: #807F80 !important; text-align: left;
                                        line-height: 12px;">
                                        <%-- <a target="_blank" href='/Internal/Merchandising/QualityControl.aspx?orderDetailID=<%# Eval("OrderDetailID") %>&styleid=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID.ToString() %>&stylenumber=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.sCodeVersion.ToString() %>&FitsStyle=<%# (Eval("ParentOrder") as iKandi.Common.Order).Fits.StyleCodeVersion %>&ClientID=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.client.ClientID %>&DeptId=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.cdept.DeptID %>&showHOPPMFORM=Yes'>--%>
                                        <asp:Label ID="lblTopSent" runat="server" ToolTip="Assurance Form" Text="TOP Sent"
                                            Visible='<%# Eval("FitsTOPSentRead")%>'>

                                        </asp:Label>
                                        <%--  </a>--%>
                                    </td>
                                    <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                        <%-- <a title="CLICK TO SEE INLINE FORM" target="InlinePPMForm" href="/Internal/Production/InlinePPMEdit.aspx?styleid=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID %>&stylenumber=<%# (Eval("ParentOrder") as iKandi.Common.Order).Style.StyleCode %>">--%>
                                        <%--Added By Ashish on 23/3/2015--%>
                                        <%--Edited by abhishek on 8/1/2015--%>
                                        <%--<asp:Label ID="Label10" Visible='<%# Eval("FitsTopSentTargetDateRead")%>' ToolTip="Top Sent Target Date"
                            Style="font-size: 8px !important; font-weight: bold;" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget) == Convert.ToDateTime("01/01/0001")) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentTarget.ToString("dd MMM (ddd)")%>'
                            runat="server"></asp:Label>--%>
                                        <asp:Label ID="Label10" Visible='<%# Eval("FitsTopSentTargetDateRead")%>' ToolTip="Top Sent Target Date"
                                            Style="font-size: 8px !important; font-weight: bold;" Text='<%# (Convert.ToDateTime(Eval("TOPTargetETA")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("TOPTargetETA"))).ToString("dd MMM")%>'
                                            runat="server"></asp:Label>
                                        <%--end by abhishek on 8/1/2015--%>
                                        <asp:Label ID="lblTopSendTarget" Visible='<%# Eval("FitsTopSentMActualDateRead")%>'
                                            Enabled='<%# Eval("FitsTopSentMActualDateWrite")%>' Style="width: 98%; font-size: 8px !important;
                                            display: none;" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual) == Convert.ToDateTime("01-01-0001")) ? "" : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual.ToString("dd MMM")%>'
                                            runat="server"></asp:Label>
                                        <%--END--%>
                                        <%-- </a>--%>
                                    </td>
                                    <td style='color: #00E; text-align: center; padding: 0px; <%# "background-color :" + Eval("FitsTOPSentETABackColor").ToString() %>'>
                                        <asp:TextBox ID="lblTOPETA" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsTOPSentETABackColor"))%>'
                                            ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("FitsTOPSentETAForColor"))%>'
                                            Visible='<%# Eval("FitsTOPSentETARead")%>' runat="server" Style="width: 98%;
                                            height: 20px; text-align: center; border: 0px; font-size: 8px; text-transform: capitalize;"
                                            CssClass="do-not-allow-typing" Text='<%# (Convert.ToDateTime((Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual) == Convert.ToDateTime("01-01-0001")) ? (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM") : (Eval("ParentOrder") as iKandi.Common.Order).InlinePPMOrderContract.TopSentActual.ToString("dd MMM")%>'></asp:TextBox>
                                        <span visible="false" id="spantoppending" runat="server"><a onclick="javascript:return showEtaPopup('TOPETA','FitsETA','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>','','','<%# (Convert.ToDateTime(Eval("TOPETA")) == Convert.ToDateTime("01-01-0001")) ? "" : Convert.ToDateTime(Eval("TOPETA")).ToString("dd MMM")%>','','<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>','','<%#Eval("OrderDetailID") %>',64);">
                                            <asp:TextBox ID="lbltoppending" CssClass="do-not-allow-typing" Style="font-size: 8px !important;
                                                color: red !important; background-color: transparent;" runat="server" Width="98%"
                                                Text='<%# Eval("TOPpending")%>'></asp:TextBox>
                                        </a></span>
                                    </td>
                                </tr>
                                <tr id="apprHide5" runat="server">
                                    <td id="tdTestReport" runat="server" style="color: #807F80 !important; text-align: left;
                                        line-height: 12px;">
                                        <%--<asp:HyperLink ID="hlnktestupload" runat="server" Style="cursor: pointer;" Target="_blank" Text="">
                           
                           </asp:HyperLink>--%>
                                        <a title="Mo Test Report Upload Form" target="_blank" href="../../Internal/OrderProcessing/MoTestReportUpload.aspx?OrderId=<%# Eval("OrderID")%>&OrderDetailsId=<%# Eval("OrderDetailID")%>"
                                            onclick='return OpenTestReport(this);' style="cursor: pointer; text-decoration: none;">
                                            <asp:Label ID="lbltextreport" runat="server" ToolTip="Test Report files" Style="color: Gray;"
                                                Text="" Visible='<%# Eval("FitsHOPPMRead")%>'></asp:Label></a>
                                        <%--<asp:HyperLink ID="hlnViewUpload" runat="server" Style="cursor: pointer;" ImageUrl="../../App_Themes/ikandi/images/zoom_icon1.gif" Target="_blank"></asp:HyperLink>--%>
                                    </td>
                                    <td style="color: Black; text-align: center; padding: 0px !important; margin: 0px !important;">
                                        <div style="width: 100%; border-bottom: 1px solid #dddada; height: 12px;">
                                            <asp:Label ID="lbltestReportTagrgetsDates" Visible='<%# Eval("FitsHOPPMTargetDateRead")%>'
                                                ToolTip="Test Report Target Date" CssClass="date_style  do-not-allow-typing"
                                                Style="font-size: 8px; font-weight: bold;" runat="server" Text='<%# (Convert.ToDateTime(Eval("TestReportTargetETA")) == Convert.ToDateTime("1/1/1900")||Convert.ToDateTime(Eval("TestReportTargetETA")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("TestReportTargetETA")) == Convert.ToDateTime("01-01-0001")) ? "" : (Convert.ToDateTime(Eval("TestReportTargetETA"))).ToString("dd MMM")%>'></asp:Label>
                                        </div>
                                        <asp:Label ID="lblTestReportActualDate" Visible='<%# Eval("FitsHOPPMActualDateRead")%>'
                                            Enabled='<%# Eval("TestReportWrite")%>' ToolTip="Test Report Actual Date" Style="width: 98%;
                                            font-size: 8px !important; background-color: #F9F9FA !important; text-transform: capitalize !important;"
                                            Text='<%# (Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01/01/0001")||Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("1/1/1900")) ? (Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateActual")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("TestReportsDateActual")).ToString("dd MMM")  : Convert.ToDateTime(Eval("TestReportsDateActual")).ToString("dd MMM") %>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style='color: #00E; text-align: center; padding: 0px !important; <%# "background-color :" + Eval("TestReportsBackColor").ToString() %>'>
                                        <span id="span1" runat="server">
                                            <asp:TextBox ID="TxtETATestReport" Width="98%" BackColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TestReportsBackColor"))%>'
                                                ForeColor='<%# System.Drawing.ColorTranslator.FromHtml((String)Eval("TestReportsForColor"))%>'
                                                onchange="javascript:return UpdateCuttingSheetDateForMO(this,'TESTREPORTS');"
                                                Style="font-size: 8px !important; text-transform: capitalize !important; height: 20px;
                                                text-align: center; border: 0px;" runat="server" Text='<%# (Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01/01/0001")) ? (Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01-01-0001")||Convert.ToDateTime(Eval("TestReportsDateETA")) == Convert.ToDateTime("01/01/0001")) ? "" : Convert.ToDateTime(Eval("TestReportsDateETA")).ToString("dd MMM")  : Convert.ToDateTime(Eval("TestReportsDateETA")).ToString("dd MMM") %>'></asp:TextBox>
                                        </span>
                                        <asp:HiddenField ID="hdnOrderDetailsID" runat="server" Value='<%#Eval("OrderDetailID") %>' />
                                        <asp:HiddenField ID="hdnStyle" runat="server" Value='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleNumber%>' />
                                        <asp:HiddenField ID="hdnOrderId" runat="server" Value='<%#Eval("OrderID") %>' />
                                        <asp:HiddenField ID="hdnStyleID" runat="server" Value='<%#(Eval("ParentOrder") as iKandi.Common.Order).Style.StyleID%>' />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                    <ItemStyle CssClass="newcss2"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="width: 100px; margin: 5px auto;">
            <asp:Button ID="btnclose" runat="server" CssClass="da_submit_button himeme" Text="close"
                OnClientClick="javascript:self.parent.Shadowbox.close();" />
        </div>
    </div>
    </form>
</body>
</html>
