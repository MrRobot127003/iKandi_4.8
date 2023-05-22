<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanningMatrix.aspx.cs"
    Inherits="iKandi.Web.Internal.Production.ProductionPlanningMatrix" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../App_Themes/ikandi/ikandi1.css" />
    <style type="text/css">
        body
        {
            font-size: 11px;
            font-family: Arial;
        }
        .fitsstatus span
        {
            font-size: 7px !important;
        }
        h2
        {
            color: #98a9ca !important;
            font-family: Arial,sans-serif;
            font-size: 11px;
            padding: 10px 0px;
            background-color: #39589c;
            text-transform: capitalize !important;
            width: 100%;
            text-align: center;
        }
        
        .item_list th
        {
            background-color: #e9e9e9 !important;
            color: #575759 !important;
            font-size: 10px !important;
            font-weight: normal;
            line-height: 15px;
            text-align: left;
            padding: 5px 3px !important;
            height: auto;
            text-transform: capitalize !important;
        }
        .item_list td span
        {
            color: Blue;
            font-size: 9px;
            text-transform: capitalize !important;
        }
        .item_list td
        {
            font-size: 9px;
            text-transform: capitalize !important;
            border-color: Gray;
            padding: 2px !important;
            padding-left: 4px !important;
        }
        .align-left
        {
            text-align: left !important;
        }
        .align-center
        {
            text-align: center !important;
        }
        .TotalBackColor td
        {
            background-color: #e9e9e9 !important;
            font-size: 10px;
            font-weight: bold;
            color: Gray;
            text-align: center;
            vertical-align: middle;
            border-color: #c1c0c099 !important;
            font-family: Arial;
        }
        
        .item_list_matrix th
        {
            height: 20px;
            background: #cacfd2;
            color: #666 !important;
            text-align: center;
            text-transform: capitalize !important;
        }
        .item_list_matrix td span
        {
            vertical-align: middle;
            width: 90%;
            font-size: 11px;
        }
        
        .item_list_matrix td
        {
            text-align: center;
        }
        .item_listLine th
        {
            height: 15px;
            padding: 2px;
            background: #428bca;
            color: #fff;
        }
        .item_listLine td
        {
            text-align: center;
        }
        .item_listLine td span
        {
            vertical-align: middle;
            width: 90%;
            text-align: center;
        }
        
        .border2 th
        {
            text-align: center;
            font-size: 10px;
            font-family: arial, halvetica;
            color: #666;
            font-weight: normal;
            padding: 0px;
            background: #cacfd2;
        }
        .Accstyle input
        {
            width: 40px;
            vertical-align: middle;
            text-align: center;
        }
        .Accstyle
        {
            height: 20px;
            vertical-align: middle;
            width: 55px;
        }
        .Accstyle-new
        {
            height: 20px;
            vertical-align: middle;
            width: 55px;
        }
        
        .Fabtyle
        {
            height: 20px;
            vertical-align: middle;
            width: 55px;
        }
        .Fabtyle input
        {
            width: 40px;
            vertical-align: middle;
            text-align: center;
        }
        .hiddencol
        {
            display: none;
        }
        .border2 th
        {
            height: 56px !important;
        }
        .borderbottom td
        {
            height: 28px;
        }
        .ItemBackGreen
        {
            background-color: Green !important;
            color: White !important;
        }
        .ItemBackRed
        {
            background-color: Red !important;
            color: White;
        }
        
        .TotalBackStitch
        {
            background-color: Yellow !important;
            display: block;
            height: 20px;
        }
        .blue
        {
            color: Blue;
        }
        .rowcolor
        {
            background-color: #da9694 !important;
            color: White;
        }
        .rowcolor input
        {
            background-color: #da9694 !important;
            color: White;
        }
        .rowcolor .TotalBackStitch
        {
            background-color: #da9694 !important;
            color: White;
        }
        .rowcolor .days-back
        {
            background-color: #da9694 !important;
            color: black;
        }
        .days-back
        {
            color: #98a9ca;
        }
        .rowcolor span
        {
            color: White !important;
        }
        body
        {
            margin: 0;
            padding: 0;
            font-family: Arial;
        }
        .modal
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
        .center
        {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }
        .ItemBackStitch
        {
            background-color: #81DAF5;
        }
        .rotate
        {
            display: block;
            -moz-transform: rotate(-45deg); /*Safari*/
            -webkit-transform: rotate(-45deg); /*Opera*/
            -o-transform: rotate(-45deg);
            -ms-transform: rotate(-45deg); /* ie*/
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
            padding: 0px;
            border: 0px;
        }
        
        .hide-button td:nth-child(2)
        {
            display: none;
        }
        .hide-button td:nth-child(3)
        {
            display: none;
        }
        .red
        {
            background: red !important;
        }
        #grdProductionMatrixHeader
        {
            margin-right: 4px;
        }
        #grdProductionMatrixHeader td
        {
            border-color:#999;
        }
        .item_list td:first-child
        {
                border-left-color: #a9a4a4 !important;
        }
        .item_list td:last-child
        {
                border-right-color: #a9a4a4 !important;
        }
        .item_list tr:last-child > td
        {
                border-bottom-color: #949393 !important;
        }
    </style>
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../js/service.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript">
        function ChangeLineFrame(obj) {
            //debugger;
            var LinePlanframeId = obj.value;
            $(".LineFrame").val(LinePlanframeId);

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="600">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
        <ContentTemplate>
            <div style="text-align: center; width: auto; text-transform: capitalize;">
                <div style="text-align: center; padding: 1px 0px; background-color: #405D99; color: #FFFFFF;
                 font-family: Verdana; width: 100%;line-height: 20px;">
                    <div style="float: left; margin-left: 10px; width: auto;">
                        <span style="font-weight: bold;">Style Code </span><asp:Label ID="lblStylecode"
                            runat="server" ForeColor="#f5f5f5"></asp:Label>
                    </div>
                    <asp:Label ID="lblHeader" runat="server" Text="Production Planning"></asp:Label>
                    <div style="float: right; margin-right: 10px; width: auto;">
                        <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" Style="padding: 0px;text-align: right;"
                            Text="Close" Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
                <br />
                <table cellpadding="0" cellspacing="0" border="1" style="width: 295px;border-color: #9999991c;" class="item_list">
                    <tr>
                        <th width="164px" style="width:164px">
                            Total quantity on order
                        </th>
                        <td style="border: 1px solid #bdbdbd;">
                            <asp:Label ID="lblqtyorder" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="border-bottom: 0px;width:164px">
                            Total quantity Shipped
                        </th>
                        <td style="border: 1px solid #bdbdbd;border-bottom: 0px;width:122px">
                            <asp:Label ID="lblshipedqty" Font-Bold="true" Font-Size="10px" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grdProductionMatrixHeader" runat="server" AutoGenerateColumns="false"
                    ShowHeader="true" ShowFooter="false" OnRowDataBound="grdProductionMatrixHeader_RowDataBound"
                    CssClass="item_list" Style="width: auto !important;">
                </asp:GridView>
                <div style='text-align: left; margin-left: -2px; margin-top: 5px;'>
                    &nbsp;
                    <asp:Label ID="lblMessage" Font-Bold="true" Font-Size="12px" ForeColor="Red" runat="server"
                        Text=""></asp:Label>
                    </div>
                <div style="text-align: right; padding-right: 5px; text-transform: capitalize;">
                    <span id="dvLinePlanFrame" visible="false" runat="server" style="padding: 4px; border: 1px solid gray;
                        text-transform: capitalize;">
                        <asp:Label ID="lblLinePlanFrame" runat="server" Text="Select Frame No."></asp:Label>&nbsp;&nbsp;<asp:DropDownList
                            ID="ddlLinePlanFrame" onclick="javascript:ChangeLineFrame(this);" runat="server">
                        </asp:DropDownList>
                    </span>&nbsp;
                    <asp:Button ID="btnShowMatrix" runat="server" Text="Show Matrix" class="da_submit_button"
                        OnClick="btnShowMatrix_Click" />
                    <asp:Button ID="btnHideMatrix" runat="server" CssClass="da_submit_button" Visible="false"
                        Text="Hide Matrix" OnClick="btnHideMatrix_Click" />
                    <%--  <asp:TextBox ID="txtLineFrame" CssClass="LineFrame" style="display:none;" Text="-1" runat="server"></asp:TextBox>--%>
                    
                </div>
                <div>
                    <table id="tblMatrixHdr" runat="server" class="item_list_matrix" style="width: 90%;
                        border: 1px solid #ddd;">
                        <tr>
                            <th width="7.5%" style="padding-left:2px">
                                Total Wrk Hrs
                            </th>
                            <td width="7.5%">
                                <asp:Label ID="lblWorkingHrs" runat="server" Text=""></asp:Label>
                            </td>
                            <th width="7.5%" style="padding-left:2px">
                                Line Qty
                            </th>
                            <td width="7.5%" style="padding-left:2px">
                                <asp:Label ID="lblLineQty" CssClass="number-with-commas" runat="server" Text=""></asp:Label>
                            </td>
                            <th width="7.5%" style="padding-left:2px">
                                Act. Stitched
                            </th>
                            <td width="7.5%">
                                <asp:Label ID="lblActualStitched" CssClass="number-with-commas" runat="server" Text=""></asp:Label>
                            </td>
                            <th width="7.5%" style="padding-left:2px">
                                SAM
                            </th>
                            <td width="7.5%">
                                <asp:Label ID="lblSAM" runat="server" Text=""></asp:Label>
                            </td>
                            <th width="6%" style="padding-left:2px">
                                OB
                            </th>
                            <td width="7.5%">
                                <asp:Label ID="lblOB" runat="server" Text=""></asp:Label>
                            </td>
                            <th width="7.5%" style="padding-left:2px">
                                Avail Mins
                            </th>
                            <td width="7.5%">
                                <asp:Label ID="lblAvailMins" runat="server" Text=""></asp:Label>
                            </td>
                            <th width="6%" style="padding-left:2px">
                                Line No
                            </th>
                            <td width="7.5%">
                                <asp:Label ID="lblLines" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnExFactory" runat="server" Value="" />
                            </td>
                        </tr>
                    </table>
                    <table id="tblMatrixGrid" runat="server" cellpadding="0" cellspacing="0" style="width: auto;">
                        <tr>
                            <td>
                                <asp:GridView ID="grdProductionMatrix" runat="server" AutoGenerateColumns="false"
                                    CellPadding="0" CssClass="border2" DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true"
                                    EmptyDataRowStyle-ForeColor="Red" EmptyDataText="There is no Line Plan for this contract."
                                    OnRowDataBound="grdProductionMatrix_RowDataBound" RowStyle-Font-Size="10px" ShowFooter="false"
                                    Style="width: 525px;" Width="100%">
                                    <RowStyle CssClass="borderbottom" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="55px" HeaderText="Serial no."
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="115px" HeaderText="Contract no."
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="125px" HeaderText="Color/Print"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColor" runat="server" Text='<%# Eval("FabricDetails")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="75px" HeaderText="Cal. Date"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <div style="text-align: left; padding-left: 10px;">
                                                    <asp:Label ID="lblLinePlanningDate" runat="server" BorderColor="White" CssClass="do-not-allow-typing"
                                                        Text='<%# Eval("LinePlanningDate", "{0:dd MMM (ddd)}")%>' Width="95%"></asp:Label>
                                                </div>
                                                <asp:HiddenField ID="hdnOrderDetailId" Value='<%# Eval("OrderDetailId")%>' runat="server" />
                                                <asp:HiddenField ID="hdnStartSlot" Value='<%# Eval("StartSlot")%>' runat="server" />
                                                <asp:HiddenField ID="hdnEndSlot" Value='<%# Eval("EndSlot")%>' runat="server" />
                                                <asp:HiddenField ID="hdnEfficiency" Value='<%# Eval("Efficiency")%>' runat="server" />
                                                <asp:HiddenField ID="hdnStitching" Value='<%# Eval("Stitching")%>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="45px" HeaderText="Act. Cal. Wrk. Hrs"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWorkingHrs" runat="server" Text='<%# Eval("WorkingHrs")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="40px" HeaderText="Day Stitch"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDayStitch" CssClass="number-with-commas" runat="server" Text='<%# Eval("DayStitch")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Height="32px" HeaderStyle-Width="50px" HeaderText="Total Stitch"
                                            ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalDayStitch" runat="server" CssClass="number-with-commas" Text='<%# Eval("TotalDayStitch")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                            <td align="left" valign="top">
                                <asp:GridView ID="grdFabricAccess" runat="server" AutoGenerateColumns="false" CellPadding="0"
                                    CssClass="border2" DataFormatString="{0:#,##}" EmptyDataRowStyle-Font-Bold="true"
                                    EmptyDataRowStyle-ForeColor="Red" EmptyDataText="" RowStyle-Font-Size="10px"
                                    ShowFooter="false" Style="max-width: 1800px;" OnRowDataBound="grdFabricAccess_RowDataBound">
                                    <RowStyle CssClass="borderbottom" />
                                    <Columns>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="text-align: center;">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="modal">
                    <div class="center" style="removed: absolute; z-index: 1; removed 50%; removed 50%;">
                        <img alt="" src="../../images/loading36.gif" />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
