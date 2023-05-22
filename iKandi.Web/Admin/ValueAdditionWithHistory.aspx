<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValueAdditionWithHistory.aspx.cs"
    Inherits="iKandi.Web.Admin.ValueAdditionWithHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-size: 11px;
            font-family: verdana;
        }
        
        .txt
        {
            color: #7E7E7E;
            font-family: Arial;
            text-transform: none;
            text-align: center;
        }
        .ValuQty
        {
            border-top: 1px solid grey;
            display: inline-block;
            width: 100%;
        }
        
        .remove-head
        {
            color: #575759 !important;
            background-color: #dddfe4 !important;
            text-transform: capitalize;
            border: 1px solid #cccccc;
            text-align: center;
            padding: 5px;
            font-weight: normal !important;
            font-size: 12px !important;
        }
        
        .AddClass_Table td
        {
            text-transform: capitalize;
        }
        .AddClass_Table td
        {
            height: 21px !important;
        }
        .AddClass_Table tr:first-child > td
        {
            border: 1px solid #999 !important;
        }
        .border_bottom_color
        {
            border-bottom-color: #999 !important;
        }
        .Bottom_Table
        {
            border-bottom-color: #999 !important;
        }
    </style>
    <link href="../css/report.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.5.2-jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            borderBottomColor();
            FillTotalValueAddQtyHistory();

        });

        function FillTotalValueAddQtyHistory() {
            var cell;
            var TotalValueAddQty = 0;
            var gvDrv = document.getElementById("gvValueAdditionHistory");
            var RowCount = parseInt(gvDrv.rows.length);
            var ColumnCount = parseInt(document.getElementById("hdnColumnCount").value);

            for (i = 2; i < RowCount; i++) {
                if (gvDrv.rows[i].cells.length == 19) {
                    for (j = 3; j < (ColumnCount + 3); j++) {
                        if (gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML != '') {
                            TotalValueAddQty = parseInt(TotalValueAddQty) + parseInt(gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML);
                        }
                    }

                    if (TotalValueAddQty > 0) {
                        gvDrv.rows[i].cells[ColumnCount + 3].getElementsByTagName("span")[0].innerHTML = TotalValueAddQty;
                    }
                    else {
                        gvDrv.rows[i].cells[ColumnCount + 3].getElementsByTagName("span")[0].innerHTML = '';
                    }
                    TotalValueAddQty = 0;
                }
                else if (gvDrv.rows[i].cells.length == 18) {
                    for (j = 2; j < (ColumnCount + 2); j++) {
                        if (gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML != '') {
                            TotalValueAddQty = parseInt(TotalValueAddQty) + parseInt(gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML);
                        }
                    }

                    if (TotalValueAddQty > 0) {
                        gvDrv.rows[i].cells[ColumnCount + 2].getElementsByTagName("span")[0].innerHTML = TotalValueAddQty;
                    }
                    else {
                        gvDrv.rows[i].cells[ColumnCount + 2].getElementsByTagName("span")[0].innerHTML = '';
                    }
                    TotalValueAddQty = 0;
                }
                else {
                    for (j = 1; j < (ColumnCount + 1); j++) {
                        if (gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML != '') {
                            TotalValueAddQty = parseInt(TotalValueAddQty) + parseInt(gvDrv.rows[i].cells[j].getElementsByTagName("span")[0].innerHTML);
                        }
                    }
                    if (TotalValueAddQty > 0) {
                        gvDrv.rows[i].cells[ColumnCount + 1].getElementsByTagName("span")[0].innerHTML = TotalValueAddQty;
                    }
                    else {
                        gvDrv.rows[i].cells[ColumnCount + 1].getElementsByTagName("span")[0].innerHTML = '';
                    }
                    TotalValueAddQty = 0;
                }
            }
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

            //            var maxRowF = 0;
            //            var rowSpanF = 0;
            //            $('.PendingSummaryTable td[rowspan].firstCol').each(function () {
            //                var row = $(this).parent().parent().children().index($(this).parent());
            //                if (row > maxRowF) {
            //                    maxRowF = row;
            //                    rowSpanF = 0;
            //                }
            //                if ($(this).attr('rowspan') > rowSpanF) rowSpanF = $(this).attr('rowspan');
            //            });
            //            if (maxRowF == $('.PendingSummaryTable tr:last td').parent().parent().children().index($('.PendingSummaryTable tr:last td').parent()) - (rowSpanF - 1)) {
            //                $('.PendingSummaryTable td[rowspan].firstCol').each(function () {
            //                    var row = $(this).parent().parent().children().index($(this).parent());
            //                    if (row == maxRowF && $(this).attr('rowspan') == rowSpanF) $(this).addClass('border_bottom_color');
            //                });
            //            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 99.5%; margin-left: 0px;
        margin-top: 5px;" align="center">
        <tr>
            <td style="background-color: #405D99; color: #FFFFFF; font-size: 15px; padding: 2px 0px;
                text-align: center; font-family: Arial;">
                History
            </td>
        </tr>
        <%-- <tr>
        <td  style="height:10px;">
       <b> <asp:Label ID="lbltotal" runat="server"></asp:Label> </b>
        </td>
      </tr>--%>
        <tr>
            <td align="center">
                <asp:HiddenField ID="hdnColumnCount" runat="server" />
                <asp:GridView ID="gvValueAdditionHistory" runat="server" Width="100%" AutoGenerateColumns="false"
                    OnRowDataBound="gvValueAdditionHistory_RowDataBound" OnRowCreated="gvValueAdditionHistory_RowCreated"
                    OnDataBound="gvValueAdditionHistory_DataBound" ShowHeader="false" CssClass="AddClass_Table PendingSummaryTable">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="156px">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblFromStatus_ToStatus" runat="server" Text='<%#Eval("FromStatus_ToStatus") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="CollspanBottom" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="140px">
                            <%-- <HeaderTemplate></HeaderTemplate>--%>
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnValueAdditionId" runat="server" Value='<%#Eval("ValueAdditionID") %>' />
                                <asp:Label ID="lblValueAdditionName" runat="server" Text='<%#Eval("ValueAdditionName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                            <%--   <HeaderTemplate></HeaderTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
