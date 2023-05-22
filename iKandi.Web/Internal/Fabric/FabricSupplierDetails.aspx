<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricSupplierDetails.aspx.cs"
    Inherits="iKandi.Web.Internal.Fabric.FabricSupplierDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            font-family: arial;
            border-color: gray;
            border-collapse: collapse;
        }
        
        
        .grdgsmcom td
        {
            font-size: 10px;
            text-align: center;
            border-color: #aaa;
            text-transform: capitalize;
            color: gray;
            padding: 2px 0px;
            font-family: arial;
            border-color: #999;
            padding: 5px 0px;
            font-weight: 500;
        }
  .grdgsmcom1 td
        {
           background-color:#ffc9c6;
             font-size: 10px;
            text-align: center;
            border-color: #aaa;
            text-transform: capitalize;
            color: #505050;
            padding: 2px 0px;
            font-family: arial;
            border-color: #999;
            padding: 5px 0px;
            font-weight: 500;
        }
  .grdgsmcom1 td[colspan="3"] {
            background-color: transparent;
  }
        #sb-body-inner
        {
            background: #fff;
        }
        
        .grdgsmcom th
        {
            background: #dddfe4;
            color: #575759;
            text-align: center;
            border: 1px solid #999;
            font-size: 10px;
            font-family: arial;
            padding: 3px 0px;
            font-weight: 500;
        }
        
        
        .maincontentcontainer
        {
            width: 700px;
            margin: 0px auto;
            height: 220px;
            background: #f3f3f3;
            overflow-y: hidden;
        }
        
        .decoratedErrorField
        {
            width: 27% !important;
            border: 2px solid red !important;
        }
        
        .UsernameColor
        {
            font-weight: 600;
        }
        
        
        /* #grdfinishing td[rowspan]:first-child
    {
         border-bottom-color: #999 !important; 
     }  */
        
        .tab1greige
        {
            cursor: pointer;
        }
        .clsDivHdr
        {
            background: #dddfe4;
            font-weight: 500;
            color: #575759;
            font-family: arila;
            font-size: 11px;
            padding: 5px 0px;
            text-align: center;
            text-transform: capitalize;
            width: 544px;
        }
        .color_black
        {
            color: Black;
        }
        td[colspan="6"]
        {
            padding: 0px 0px !important;
            border: 0px;
        }
        td[colspan="4"]
        {
            padding: 0px 0px !important;
            border: 0px;
        }
    </style>
    <script>
        function HideSupplierDiv() {
            //  alert();
            self.parent.Shadowbox.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="clsDivHdr" id="dvHeader" runat="server" style="width: 100%; background: #39589c !important;
            color: #fff">
            All Quotations <span style="float: right; padding-right: 10px; cursor: pointer; color: #fff"
                title="Close" onclick="HideSupplierDiv();">x</span>
        </div>
        <asp:GridView ID="grdSupplier" CssClass="grdgsmcom" runat="server" AutoGenerateColumns="False"
            ShowHeader="true" EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial"
            HeaderStyle-HorizontalAlign="Center" BorderWidth="0" CellPadding="0" rules="all"
            HeaderStyle-CssClass="ths" OnDataBound="grdSupplier_DataBound" Style="border: 1px solid #999;
            width: 100%" OnRowDataBound="grdSupplier_RowDataBound">
            <SelectedRowStyle BackColor="#A1DCF2" />
            <RowStyle CssClass="RowCountDy" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td style="border: 0px;">
                                    Fabric Quality (GSM) C&C Width<br>
                                    Color/Print
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="130px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblcolorprint" Font-Bold="true" CssClass="color_black" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Best Quote For Ref.">
                    <ItemTemplate>
                        <asp:Label ID="lblIdealRate" CssClass="color_black" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" BackColor="lightgreen" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier Name">
                    <ItemTemplate>
                        <asp:Label ID="lblsuppliername" ForeColor="gray" Text='<%# Convert.ToString(Eval("SupplierName")) == "0" ? "" : Convert.ToString(Eval("SupplierName"))%>'
                            runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="180px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quoted (Rate & Lead Time)">
                    <ItemTemplate>
                        <asp:Label ID="lblQuotedLandedRate" CssClass="color_black" runat="server" Text='<%# Convert.ToString(Eval("QuotedLandedRate")) == "0" ? "" : Convert.ToString(Eval("QuotedLandedRate"))%>'></asp:Label>
                        &nbsp;<asp:Label ID="lblQuotedLeadTime" ForeColor="gray" runat="server" Text='<%# Convert.ToString(Eval("LeadTimes")) == "0" ? "" : Convert.ToString(Eval("LeadTimes"))%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="topsupplier" style="width: 100%">
                    <tr>
                        <th style="border-top: 0px; border-left: 0px;">
                            Fabric Quality (GSM) C&C Width<br>
                            Color/Print
                        </th>
                        <th style="border-top: 0px;">
                            Best Quote For Ref.
                        </th>
                        <th style="border-top: 0px;">
                            Supplier Name
                        </th>
                        <th style="border-top: 0px; border-right: 0px;">
                            Quoted (Rate & Lead Time)
                        </th>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <img src="../../images/sorry.png" alt="No record found" class="ImgCenter">
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblEmptyRow" Style="font-size: 12px; color: Red; display: none;" runat="server"
                    Text="Data not available"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <%--  <div>PO Details </div>--%>
        <div class="clsDivHdr" id="Div1" runat="server" style="width: 100%; margin-top:10px; background: #39589c !important;
            color: #fff">
            Last Purchase Order Details
            <%--<span style="float: right; padding-right: 10px; cursor: pointer; color: #fff">No of PO dispalyed:
            <asp:TextBox ID="txtNoofPO" runat="server" Width="10px" MaxLength="1" Text="3"></asp:TextBox>
            </span>--%>
        </div>
        <asp:GridView ID="gridPO" runat="server" 
            EnableModelValidation="True" Visible="true"
            CssClass="grdgsmcom1" AutoGenerateColumns="true"
            ShowHeader="true" EmptyDataText="No Record Found!" HeaderStyle-Font-Names="Arial"
            HeaderStyle-HorizontalAlign="Center" BorderWidth="0" CellPadding="0" rules="all"
            HeaderStyle-CssClass="ths" OnDataBound="grdSupplier_DataBound" Style="border: 1px solid #999;
            width: 100%;" >
        </asp:GridView>
    </div>
    </form>
</body>
</html>
