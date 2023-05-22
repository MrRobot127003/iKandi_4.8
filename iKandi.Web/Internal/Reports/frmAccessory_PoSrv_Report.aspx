<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAccessory_PoSrv_Report.aspx.cs" Inherits="iKandi.Web.Internal.Reports.frmAccessory_PoSrv_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <asp:GridView ID="GrdAccessoryPoSrvReport" runat="server" AutoGenerateColumns="false"
            ShowHeader="false" CssClass="AddClass_Table" OnRowCreated="GrdAccessoryPoSrvReport_RowCreated"
            OnDataBound="GrdAccessoryPoSrvReport_DataBound" OnRowDataBound="GrdAccessoryPoSrvReport_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblAccessoryName" Text='<%#Eval("AccessoryName")%>' ForeColor="Blue"
                            runat="server"></asp:Label>
                        <asp:Label ID="lblSize" Text='<%#Eval("Size")%>' runat="server"></asp:Label><br />
                        <asp:Label ID="lblColorPrint" Text='<%#Eval("Color_Print")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                      <ItemStyle Width="100px" CssClass="txtLeft" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblPOType" Text='<%#Eval("POType")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblSupplierPoid" Text='<%#Eval("SupplierPO_Id")%>' runat="server"></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblPO_Number" Text='<%#Eval("PO_Number")%>' runat="server"></asp:Label><br />
                        <asp:Label ID="lblGarmentUnitName" Text='<%#Eval("GarmentUnitName")%>' runat="server"></asp:Label>
                        <asp:HiddenField ID="hdnUnitChange" Value='<%#Eval("UnitChange")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblTotalPoQty" Text='<%#Eval("TotalPoQty")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblPODate" Text='<%#Eval("PODate")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblPartyChallanNum" Text='<%#Eval("PartyChallanNumber")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblSRVQty" Text='<%#Eval("SRVQty")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblFoPointRecievedQty" Text='<%# Eval("ForPointRecievedQty", "{0:#,##}") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblForPointCheckQty" Text='<%# Eval("ForPointCheckQty", "{0:#,##}") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblPassQty" Text='<%# Eval("PassQty", "{0:#,##}") %>' ForeColor="green" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblFailQty" Text='<%# Eval("FailQty", "{0:#,##}") %>' ForeColor="red" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblHoldQty" Text='<%# Eval("HoldQty", "{0:#,##}") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblPOStatus" Text='<%#Eval("POStatus")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
