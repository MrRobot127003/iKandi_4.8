<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StitchQtyEntryPopUp.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.StitchQtyEntryPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<script type="text/javascript" src="../../js/facebox.js"></script>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script src="../../js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../../js/jquery.fancybox.js" type="text/javascript"></script>
    <script src="../../js/facebox.js" type="text/javascript"></script>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            borderBottomColor();
        })
        function ValidateZero(textbox) {
            //jQuery.facebox(textbox.id);
            var ValueAddQty = document.getElementById(textbox.id).value;
            if (parseInt(ValueAddQty) <= 0) {
                jQuery.facebox("Value must be greater than zero !");
                textbox.value = textbox.defaultValue;
                return;
            }
        }
        function ValidateQty(elem) {
            //debugger;   
            var type = document.getElementById("hdnType").value;

            var EntryVal = document.getElementById("txtQty").value;

            var ManPower = document.getElementById("txtManPower").value;
            var hdnQty = document.getElementById("hdnQty").value;
            var RemainingQty = document.getElementById("lblTotalRemaining").innerHTML;
            var TotalVal = 0;

            if (hdnQty == "")
                hdnQty = 0;

            if (RemainingQty == "")
                RemainingQty = 0;

            if (type == "Stitch") {
                if (EntryVal != "" && ManPower == "") {
                    jQuery.facebox("Manpower cannot be empty !")
                    elem.value = elem.defaultValue;
                    return;
                }
            }
            if (EntryVal != "") {
                if (parseInt(EntryVal) == 0) {
                    // commented on the request of Padam IE on dated 18 june 2019
                    //                    jQuery.facebox("Stitch Qty can not be zero !");
                    //                    elem.value = '';
                    //                    return;
                }
                TotalVal = parseInt(EntryVal) + parseInt(hdnQty);

                if (parseInt(TotalVal) > parseInt(RemainingQty)) {
                    if (type == "Stitch") {
                        jQuery.facebox("Stitch Qty can not be greater than Cut Issue !");
                    }
                    else if (type == "Finish") {
                        jQuery.facebox("Finish Qty can not be greater than Stitch Qty !");
                    }
                    elem.value = '';
                    document.getElementById("SpnQty").innerHTML = "(" + hdnQty + ")";
                    return;
                }
                document.getElementById("SpnQty").innerHTML = "(" + TotalVal + ")";
            }
            else {
                TotalVal = parseInt(hdnQty);
                document.getElementById("SpnQty").innerHTML = "(" + TotalVal + ")";
            }

        }

        function ValidateOnSubmit() {
            //debugger;
            var type = document.getElementById("hdnType").value;
            var EntryVal = $("#" + '<%=txtQty.ClientID%>').val();
            var QC = $("#" + '<%=ddlQC.ClientID%>').val();
            var QCChecker = $("#" + '<%=ddlChecker.ClientID%>').val();

            //            if ((EntryVal == '0') || (EntryVal == '')) {
            //                if (type == "Stitch") {
            //                    // commented on the request of Padam IE on dated 18 june 2019
            //                    // jQuery.facebox("Stitch Qty can not be 0 or empty !");
            //                }
            //                else {
            //                    jQuery.facebox("Finish Qty can not be 0 or empty !");
            //                    $("#" + '<%=txtQty.ClientID%>').focus();
            //                    return false;
            //                }
            //            }

            if (QC == '0') {
                jQuery.facebox("Please select QC !");
                $("#" + '<%=ddlQC.ClientID%>').focus();
                return false;
            }
            if (QCChecker == '0') {
                jQuery.facebox("Please select QC Checker!");
                $("#" + '<%=ddlChecker.ClientID%>').focus();
                return false;
            }

            $("#" + '<%=btnSubmit.ClientID%>').hide();
        }
        function borderBottomColor() {
            
            var maxRow = 0;
            var rowSpan = 0;
            $('.PendingSummaryTable td[rowspan]').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRow) {
                    maxRow = row;
                    rowSpan = 0;
                }
                if ($(this).attr('rowspan') > rowSpan) rowSpan = $(this).attr('rowspan');
            });
            if (maxRow == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpan - 1)) {
                $('.PendingSummaryTable td[rowspan]').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRow && $(this).attr('rowspan') == rowSpan) $(this).addClass('border_bottom_color');
                });
            }

            var maxRowF = 0;
            var rowSpanF = 0;
            $('.PendingSummaryTable td[rowspan].firstCol').each(function () {
                var row = $(this).parent().parent().children().index($(this).parent());
                if (row > maxRowF) {
                    maxRowF = row;
                    rowSpanF = 0;
                }
                if ($(this).attr('rowspan') > rowSpanF) rowSpanF = $(this).attr('rowspan');
            });
            if (maxRowF == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpanF - 1)) {
                $('.PendingSummaryTable td[rowspan].firstCol').each(function () {
                    var row = $(this).parent().parent().children().index($(this).parent());
                    if (row == maxRowF && $(this).attr('rowspan') == rowSpanF) $(this).addClass('border_bottom_color');
                });
            }
        }
    </script>
    <style type="text/css">
        .center-table table
        {
            margin: 0px auto;
        }
        input type["text"]
        {
            text-transform: capitalize;
            width: 100%;
        }
        td
        {
            text-transform: capitalize !important;
        }
        .input[type=text], textarea
        {
            border: 1px solid #cccccc;
            text-transform: capitalize;
            font-size: 11px;
        }
        SELECT
        {
            text-transform: capitalize;
        }
        .AddClass_Table td
        {
            padding: 4px 4px;
            border: 1px solid #dbd8d8;
        }
        .AddClass_Table th
        {
            padding: 4px 4px;
        }
        .AddClass_Table tr:last-child > td
        {
            border-bottom-color: #999 !important;
        }
        .btnTextChange
        {
           color: blue;
            cursor: pointer;
            width: 80px;
            padding-left: 10px;
            text-decoration: underline;
        }
        #HideHistory
        {
            display:none;
         }
         .border_bottom_color
         {
             border-bottom-color:#999 !important;
           }
    </style>
    <form id="form1" runat="server" class="center-table">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uproTargetAdmin" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <img src="../../App_Themes/ikandi/images1/loading36.gif" alt="" style="position: fixed;
                z-index: 52111; top: 40%; left: 45%; width: 6%;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         
            <table border="0" class="AddClass_Table" cellpadding="0" cellspacing="0" style="width: 100%"
                align="center">
                <tr>
                    <td style="padding: 2px 0px;text-align: center; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                        font-size: 12px; text-transform: none;">
                        <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="lblFactoryName" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hdnType" runat="server" />
                    </td>
                </tr>
            </table>
            <table border="0" class="AddClass_Table" cellpadding="0" cellspacing="0" style="width: 99.8%"
                align="center">
                <tr>
                    <th style="width: 45px;">
                        ManPower
                    </th>
                    <th style="width: 65px;">
                        <asp:Label ID="lblTotalValueHdr" runat="server" Text=""></asp:Label>
                    </th>
                    <th style="width: 120px;">
                        <asp:Label ID="lblTotalValue" runat="server" Text=""></asp:Label>
                    </th>
                    <th>
                        QC
                    </th>
                    <th>
                        Checker
                    </th>
                    <th>
                        <asp:Label ID="lblCompleted" runat="server" Text=""></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtManPower" onchange="ValidateZero(this);" MaxLength="3" Text=""
                            class="gray" Style="text-align: center" runat="server" Width="90%" onkeypress='return event.charCode >= 48 && event.charCode <= 57'></asp:TextBox>
                        <asp:HiddenField runat="server" ID="HdnManpower" Value="0" />
                        <asp:HiddenField runat="server" ID="hdnChangeManpower" />
                    </td>
                    <td>
                        <asp:Label ID="lblTotalRemaining" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQty" onchange="ValidateQty(this);" MaxLength="5" Text="" class="gray"
                            Style="text-align: center; font-size: 10px; float: left;" runat="server" Width="60%"
                            onkeypress='return event.charCode >= 48 && event.charCode <= 57'></asp:TextBox>
                        <b><span id="SpnQty" title="overall quantity" style="text-align: right; font-size: 10px;
                            float: right;" runat="server"></span>
                            <asp:HiddenField ID="hdnQty" Value="0" runat="server" />
                        </b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlQC">
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnChangeQC" />
                        <asp:HiddenField runat="server" ID="hdnChangeTopBoth" Value="0" />
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlChecker">
                        </asp:DropDownList>
                        <asp:HiddenField runat="server" ID="hdnQcCheckerID" Value="0" />
                    </td>
                    <td>
                        <asp:CheckBox ID="chkisCom" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="text-align: right; margin-right: 25px; margin-bottom: 10px;">
              <div style=" float:left; width: 44%;">
                    <div id="clickFunction" class="btnTextChange" onclick="ViewHistoryFun(this)">
                        View History</div>
                </div>
                <asp:Button ID="btnSubmit" runat="server" title="Save record !" CssClass="do-not-include submit tooltip"
                    Text="Submit" OnClick="btnSubmit_Click" OnClientClick="javascript:return ValidateOnSubmit();" />
                <asp:Button ID="btnclose" title="Close this popup !" runat="server" CssClass="da_submit_button"
                    Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
            </div>
            <div>
              
                <div id="HideHistory">
                    <table border="0" class="AddClass_Table" cellpadding="0" cellspacing="0" style="width: 99.8%"
                        align="center">
                        <tr>
                            <td style="padding: 2px 0px;text-align:center; background-color: #405D99; color: #FFFFFF; font-weight: bold;
                                font-size: 12px; text-transform: none;">
                                History
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="grdHistory" runat="server" AutoGenerateColumns="false" RowStyle-Font-Size="11px"
                        RowStyle-HorizontalAlign="Center" Width="99.8%" EmptyDataRowStyle-Font-Bold="true"
                        ShowFooter="false" EmptyDataRowStyle-ForeColor="Red" EmptyDataText="There is no history for this contract."
                        CssClass="AddClass_Table PendingSummaryTable" OnDataBound="grdHistory_DataBound" OnRowDataBound="grdHistory_RowDataBound">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="80px" HeaderText="ManPower">
                                <ItemTemplate>
                                    <asp:Label ID="lblManPower" runat="server" Text='<%# Eval("OutHouseManpower")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="firstCol" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="80px">
                            <HeaderTemplate>
                                <asp:Label ID="lblQtyHdr" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# ( Eval("Quantity").ToString() == "0" ) ? "" :   Eval("Quantity").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="200px" HeaderText="QC">
                                <ItemTemplate>
                                    <asp:Label ID="lblQCName" runat="server" Text='<%# Eval("QCName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="200px" HeaderText="Checker">
                                <ItemTemplate>
                                    <asp:Label ID="lblQcChecker" runat="server" Text='<%# Eval("QcChecker")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="100px" HeaderText="Date">
                                <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%# (Convert.ToDateTime(Eval("HistoryDate")) == Convert.ToDateTime("1/1/1900")) ? "" : (Convert.ToDateTime(Eval("HistoryDate"))).ToString("dd MMM (ddd)")%>'></asp:Label>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">

        function ViewHistoryFun() {
            var text = $("#clickFunction").text();
            var textti = text.trim();
            if (textti == 'View History') {
                $("#clickFunction").text('Hide History');
                borderBottomColor();
            }
            if (textti == 'Hide History') {
                $("#clickFunction").text('View History');
            }
            $("#HideHistory").toggle();

        }
    </script>
</body>
</html>
