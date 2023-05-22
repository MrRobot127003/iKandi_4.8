<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_PO_SRV_Report.aspx.cs"
    Inherits="iKandi.Web.Internal.Reports.frm_PO_SRV_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style>
        td.header1
        {
            background: #e4e2e2;
            border: 1px solid #999;
            border-collapse: collapse;
            font-size: 11px;
            font-weight: 500;
            padding: 3px 3px;
            color: #6b6464;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }
        .AddClass_Table td
        {
            height: 27px;
            color: #7f7979;
            min-width: 50px;
            text-align: center;
        }
        .txtLeft
        {
            text-align: left !important;
        }
        .tableAlign
        {
            width: 64%;
            margin: 10px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
    <div class="tableAlign">
         <h2 style="width: 100%;background: #39589c;text-align:center;position: relative;height:43px;line-height:39px;">
                <div style="float: left; font-size: 10px;    padding-left: 10px; font-weight: normal; text-align: left; position:absolute ">
                    <img src="../../images/boutique-logo.png" style="width:75px;" />
                </div>
              Fabric SRV Report
            </h2>
        <asp:GridView ID="grdPO_SRV" runat="server" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Center"
            OnRowCreated="grdPO_SRV_RowCreated" ShowHeader="False" CssClass="AddClass_Table"
            OnDataBound="grdPO_SRV_DataBound" OnRowDataBound="grdPO_SRV_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblTradeName" Text='<%#Eval("TradeName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" CssClass="txtLeft" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblFabricDetail" Text='<%#Eval("FabricDetails")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblName" Text='<%#Eval("Name")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblPO_Number" Text='<%#Eval("PO_Number")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblReqQty" Text='<%#Eval("RequiredQty", "{0:#,##}")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblChallanNo" Text='<%#Eval("PartyChallanNumber")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblRecQty" Text='<%#Eval("ReceivedQty", "{0:#,##}")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblFourPointCheckRecQty" Text='<%#Eval("FourPointCheckRecQty", "{0:#,##}")%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblPassQty" Text='<%#Eval("PassQty", "{0:#,##}")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblFailQty" Text='<%#Eval("FailQty", "{0:#,##}")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblHoldQty" Text='<%#Eval("HoldQty", "{0:#,##}")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50PX">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" Text='<%#Eval("Status")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
