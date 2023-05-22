<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserTasksNew.ascx.cs"
    Inherits="iKandi.Web.UserTasksNew" %>
<style type="text/css">
    .text-bold b
    {
        font-weight: bold;
        font-size: 11px;
        text-transform: capitalize;
    }
    .text-bold
    {
        color: Black;
        text-transform: capitalize !important;
    }
    .text-font td a span
    {
        text-transform: capitalize !important;
    }
    .item_list1 a:hover
    {
        color: Blue;
    }
    .text-font
    { 
        text-transform:
    }
    .item_list1 td.txtLeft
    {
        text-align: left !important;
        padding-left: 5px !important;
    }
    .HeaderTop
    {
        top: 0px !important;
    }
    .selected_row
    {
        color: Blue;
        font-weight: bold;
    }
</style>
<script type="text/javascript" src="../../CommonJquery/Js/jquery.min.js"></script>
<script type="text/javascript">

    function ChangeColor(obj) {
        var GridRow = $(".gvRow").length;
        var RowId = 0;
        var gvId = '';
        for (var row = 1; row <= GridRow; row++) {
            RowId = parseInt(row) + 1;
            if (RowId < 10)
                gvId = 'ctl0' + RowId;
            else
                gvId = 'ctl' + RowId;

            $("#<%= grdPendingTasks.ClientID %> span[id*='" + gvId + "_lbltext" + "']").removeClass("selected_row");

        }

        $(obj).closest('span').addClass("selected_row");
    }
</script>
<div style="width: 154% !important; margin-left: 5px; max-height: 450px; overflow-y: auto;
    overflow-x: auto" id="div_li0" class="cdiv">
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" class="dashboard-holiday-app-tbl">
        <tr id="trPendingTask" runat="server">
            <td valign="top" style="padding-right: 0px;">
                <asp:GridView ID="grdPendingTasks" runat="server" AutoGenerateColumns="False" Width="100%"
                    BorderColor="#f0f0f0" OnRowDataBound="grdTasks_RowDataBound" CssClass="item_list1 dashboard_font_style fixed-header text-font"
                    CellPadding="3" CellSpacing="0">
                    <RowStyle CssClass="gvRow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Target Status" Visible="false" HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("StatusMode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Buyer" Visible="false" HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblBuyer" Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.Buyer %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial Number" Visible="false" HeaderStyle-BackColor="#f2f2f2"
                            SortExpression="" ItemStyle-CssClass=" ">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Order.SerialNumber %>'></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnOrderID" Value='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Order.OrderID %>' />
                                <asp:HiddenField runat="server" ID="hdnStyleID" Value='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.StyleID %>' />
                                <asp:HiddenField runat="server" ID="hdnOrderDetailID" Value='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Order.OrderBreakdown[0].OrderDetailID %>' />
                                <asp:HiddenField runat="server" ID="hdnStatusModeID" Value='<%# Eval("StatusModeID") %>' />
                                <asp:HiddenField runat="server" ID="hdnUserTaskType" Value='<%# Eval("UserTaskType")  %>' />
                                <asp:HiddenField runat="server" ID="hdnUserTaskName" Value='<%# Eval("Task")  %>' />
                                <asp:HiddenField ID="ValueInR" runat="server" Value='<%# Eval("BoutiqueBussiness")  %>' />
                                <asp:HiddenField ID="hdnCliID" runat="server" Value='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.ClientID %>' />
                                <asp:HiddenField runat="server" ID="hdnStyleCode" Value='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.StyleCode %>' />
                                <asp:HiddenField runat="server" ID="hdnFitStyleCodeVersion" Value='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Fit.StyleCodeVersion %>' />
                                <asp:HiddenField ID="hdnOrderDate" runat="server" Value='<%# Eval("OrderDate")  %>' />
                                <asp:HiddenField ID="hdnExfactory" runat="server" Value='<%# Eval("OrderExfactory")  %>' />
                                <asp:HiddenField ID="hdnClinetCurrency" runat="server" Value='<%# Eval("ClinetCurrency")  %>' />
                                <asp:HiddenField ID="hdnTaskDetail" runat="server" Value='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).CurrentStatus.FinalText %>' />
                                 <asp:HiddenField ID="HdnPo_number" Value='<%# Eval("PO_Number") %>' runat="server" />
                                <%--<asp:HiddenField ID="hdnqty" Value='<%# Eval("Quantity") %>' runat="server" />--%>
                                <asp:HiddenField ID="hdnSupplierName" Value='<%# Eval("Supplier") %>' runat="server" />
                                <asp:HiddenField ID="hdnAgreeRate" Value='<%# Eval("AgreeRate") %>' runat="server" />
                                <asp:hiddenField ID="hdnSerialNumber" Value='<%# Eval("SerialNumber") %>' runat="server" />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Style Number" Visible="false" HeaderStyle-BackColor="#f2f2f2"
                            SortExpression="" ItemStyle-CssClass=" ">
                            <ItemTemplate>
                                <a href="javascript:void(0)" title="CLICK TO VIEW TRACKING POPUP" onclick="showWorkflowHistory2(<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.StyleID %>, -1, -1)">
                                    <asp:Label ID="lblStyleNumber" runat="server" Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.StyleNumber %>'
                                        Style="color: #0088cc;"></asp:Label>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contract # / Line  #" HeaderStyle-BackColor="#f2f2f2"
                            SortExpression="" ItemStyle-CssClass=" " Visible="false">
                            <ItemTemplate>
                                <div>
                                    <a href="javascript:void(0)" title="CLICK TO VIEW WORKFLOW HISTORY POPUP" onclick="showWorkflowHistory2(<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.StyleID %>, -1, <%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Order.OrderBreakdown[0].OrderDetailID %>)">
                                        <asp:Label ID="Label21" runat="server" Text='<%# Eval("ContractNumber") %>' Style="color: #0088cc;"></asp:Label>
                                    </a>
                                </div>
                                <div>
                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("LineitemNumber") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" Visible="false" HeaderStyle-BackColor="#e4ebf2"
                            SortExpression="">
                            <ItemTemplate>
                                <asp:Label ID="lblQty" runat="server" Text='<%# ((Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Order.OrderBreakdown[0].Quantity == -1)? "": (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Order.OrderBreakdown[0].Quantity.ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FITs Status" Visible="false" HeaderStyle-BackColor="#f2f2f2"
                            SortExpression="" ItemStyle-Width="150px" ItemStyle-CssClass=" ">
                            <ItemTemplate>
                                <asp:Label ID="lblFitsStatus" Visible="false" CssClass="date_style" runat="server"
                                    Text='<%# (Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Order.OrderBreakdown[0].FitStatus %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Task" Visible="false" HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTask">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Target" Visible="false" HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEta" Text='<%# (Convert.ToDateTime(Eval("ETA")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("ETA"))).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="List" HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="lnkAction"   Target="_blank" Style="color: #0088cc;
                                    text-transform: capitalize;" >
                            
                                </asp:HyperLink>
                                <a id="lnk" target="_blank" runat="server">
                                    <asp:Label ID="lbltext" CssClass="text-bold" onclick="ChangeColor(this)" runat="server"
                                        Text='<%# (Convert.ToDateTime(Eval("ETA")) == DateTime.MinValue) ? "" : (Convert.ToDateTime( Eval("ETA"))).ToString("dd MMM yy (ddd)" )%>'></asp:Label>
                                </a>
                                <asp:HiddenField ID="hidept" runat="server" Value='<%# Eval("DepartmentName")  %>' />
                                <asp:HiddenField ID="Biplprice" runat="server" Value='<%# Eval("BIPLPrice")  %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="txtLeft" />
                            <HeaderStyle CssClass="HeaderTop" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" Visible="false" HeaderStyle-BackColor="#f2f2f2"
                            SortExpression="Action" ItemStyle-CssClass="lastCol ">
                            <ItemTemplate>
                                <asp:Label ID="lblCourierSentOn" runat="server" CssClass="date_style font_style8 font_back_col_yellow"
                                    Text='<%#(Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.CourierSentOn == DateTime.MinValue ? string.Empty  : "(" +(Eval("WorkflowInstance") as iKandi.Common.WorkflowInstance).Style.CourierSentOn.ToString("dd MMM yy (ddd)") + ")"%>'
                                    ToolTip="Courier Sent On Date"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr id="trProduction" runat="server">
            <td valign="top">
                <asp:GridView ID="gvProductionTask" runat="server" AutoGenerateColumns="False" Width="99%"
                    BorderColor="#f0f0f0" CssClass="item_list1 dashboard_font_style fixed-header"
                    CellPadding="3" CellSpacing="0" OnRowDataBound="gvProductionTask_RowDataBound">
                    <RowStyle CssClass="gvProductionTaskRow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#f2f2f2" SortExpression="Action"
                            ItemStyle-CssClass="lastCol ">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="lnkAction" Target="_blank" Style="color: #0088cc;"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Production Unit" HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblUnitName" Text='<%# Eval("ProductionName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnUnitId" Value='<%# Eval("ProductionUnit") %>' runat="server" />
                                <asp:HiddenField ID="hdnFactoryClassification" Value='<%# Eval("FactoryClassification") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Slot" HeaderStyle-BackColor="#f2f2f2" SortExpression=""
                            ItemStyle-CssClass=" ">
                            <ItemTemplate>
                                <asp:Label ID="lblSlot" runat="server" Text='<%# Eval("SlotName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnSlotId" Value='<%# Eval("SlotId") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Task Date" HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTaskDate" Text='<%# (Convert.ToDateTime( Eval("TaskDate"))).ToString("dd MMM yy (ddd)" )%>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" rules="all"
        style="width: 490px !important;">
        <tr id="trNotiFication" visible="false" runat="server">
            <td>
                <asp:GridView ID="grdNotiFication" runat="server" AutoGenerateColumns="false" ForeColor="Black"
                    BorderWidth="0" OnRowDataBound="grdNotiFication_RowDataBound" class="notification-table"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Events">
                            <ItemTemplate>
                                <asp:Label ID="lblmsg" runat="server" Text='<%#Eval("Remarks") %>' Style="font-size: 11px;
                                    font-family: Arial; text-transform: capitalize !important"></asp:Label>
                                <a style="font-size: 11px; font-family: Arial; color: gray; line-height: 15px; text-decoration: none;
                                    text-transform: capitalize !important" id="hlProject" runat="server" target="_blank"
                                    visible="false">
                                    <%#Eval("Remarks") %>
                                </a>
                                <div style="text-align: right; font-weight: bold; font-size: 9px; color: Gray; text-transform: capitalize !important">
                                    <asp:Label ID="lblhour" runat="server" Style='text-transform: capitalize !important'
                                        Text='<%#Eval("Days") %>'></asp:Label>
                                </div>
                                <asp:HiddenField ID="hdnStyleid" Value='<%# Eval("Styleid") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderID" Value='<%# Eval("OrderID") %>' runat="server" />
                                <asp:HiddenField ID="hdnOrderDetailsID" Value='<%# Eval("OrderDetailsID") %>' runat="server" />
                                <asp:HiddenField ID="hdnNotificationEmailHistoryID" Value='<%# Eval("NotificationEmailHistoryID") %>'
                                    runat="server" />
                                <asp:HiddenField ID="hdnIsGrouped" Value='<%# Eval("IsGrouped") %>' runat="server" />
                                <asp:HiddenField ID="hdnStylenumber" Value='<%# Eval("StyleNumber") %>' runat="server" />
                                <asp:HiddenField ID="hdnSerialNumber" Value='<%# Eval("SerialNumber") %>' runat="server" />
                                <asp:HiddenField ID="hdnisread" Value='<%# Eval("IsRead") %>' runat="server" />
                                <asp:HiddenField ID="hdnurl" Value='<%# Eval("url") %>' runat="server" />
                                <asp:HiddenField ID="hdnclintid" Value='<%# Eval("ClientID") %>' runat="server" />
                                <asp:HiddenField ID="hdnDeptid" Value='<%# Eval("Departmentid") %>' runat="server" />
                               
                                <%--hdnurl--%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="header-text" />
                            <ItemStyle CssClass="notification-text" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="2" rules="all"
        style="width: 490px !important;">
        <tr id="trtaskComplete" visible="false" runat="server">
            <td>
                <asp:GridView ID="Grdnotificatontask" runat="server" AutoGenerateColumns="false"
                    ForeColor="Black" BorderWidth="0" OnRowDataBound="Grdnotificatontask_RowDataBound"
                    class="notification-table" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText=" Task Completion">
                            <ItemTemplate>
                                <div style="width: 100%;">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div style="float: left; width: 45px;">
                                                    <asp:Image ID="img" runat="server" Width="40px" Height="40px" />
                                                </div>
                                            </td>
                                            <td valign="top">
                                                <div style="width: auto; vertical-align: middle;">
                                                    <a style="text-transform: none; color: #6e6c6c; text-decoration: none; text-transform: capitalize !important"
                                                        target="_blank">
                                                        <asp:Label ID="lblmsg" runat="server"></asp:Label></a>
                                                    <asp:HiddenField ID="status_modename" runat="server" Value='<%#Eval("status_modename") %>' />
                                                    <asp:HiddenField ID="StatusModeID" runat="server" Value='<%#Eval("StatusModeID") %>' />
                                                    <asp:HiddenField ID="StyleNumber" runat="server" Value='<%#Eval("StyleNumber") %>' />
                                                    <asp:HiddenField ID="SerialNumber" runat="server" Value='<%#Eval("SerialNumber") %>' />
                                                    <asp:HiddenField ID="CompanyName" runat="server" Value='<%#Eval("CompanyName") %>' />
                                                    <asp:HiddenField ID="DepartmentName" runat="server" Value='<%#Eval("DepartmentName") %>' />
                                                    <asp:HiddenField ID="Quantity" runat="server" Value='<%#Eval("Quantity") %>' />
                                                    <asp:HiddenField ID="ContractNumber" runat="server" Value='<%#Eval("ContractNumber") %>' />
                                                    <asp:HiddenField ID="LineItemNumber" runat="server" Value='<%#Eval("LineItemNumber") %>' />
                                                    <asp:HiddenField ID="BIPLPrice" runat="server" Value='<%#Eval("BIPLPrice") %>' />
                                                    <asp:HiddenField ID="Url" runat="server" Value='<%#Eval("Url") %>' />
                                                    <asp:HiddenField ID="hdninr" runat="server" Value='<%#Eval("INR") %>' />
                                                    <asp:HiddenField ID="ClosedDate" runat="server" Value='<%#Eval("CreatedDate") %>' />
                                                </div>
                                                <div style="text-align: right; font-weight: bold; font-size: 9px; color: Gray; vertical-align: bottom;">
                                                    <asp:Label ID="lblhour" runat="server" Style='text-transform: capitalize !important;
                                                        color: Gray;' Text='<%#Eval("DAYStask") %>'></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="clear: both;">
                                    </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="header-text" />
                            <ItemStyle CssClass="notification-text" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
