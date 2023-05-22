<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DestinationMap.aspx.cs"
    Inherits="iKandi.Web.Internal.OrderProcessing.DestinationMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style>
        .m-l-10
        {
            margin-left:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
              <asp:GridView ID="destnMap" CssClass="CommoAdmin_Table" AllowPaging="true" 
                AutoGenerateColumns="False" Width="1200px" ShowHeader="true" EmptyDataText="No records Found" PageSize="15"
                ShowHeaderWhenEmpty="True" runat="server" BorderWidth="0" OnRowDataBound="destnMap_RowDataBound">
               
                <EmptyDataRowStyle CssClass="mycentertext" />
                <Columns>
                    <asp:TemplateField HeaderText="Line Item">
                        <ItemTemplate>
                        <asp:Label ID="lblLineItem" runat="server" ForeColor="blue" Text='<%# Bind("LineItemNumber") %>'></asp:Label>
                        <asp:HiddenField ID="hdnDesination_code" runat="server" Value='<%# Bind("Desination_code") %>' />
                        <asp:HiddenField ID="hdnMode" runat="server" Value='<%# Bind("Mode") %>' />
                         <asp:HiddenField ID="hdnOrderDetailId" runat="server" Value='<%# Bind("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Dest. Code">
                        <ItemTemplate>
                          <asp:DropDownList ID="ddlDestinationCode"  ForeColor="blue" runat="server" style="width: 100%;">
                        </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contract No.">
                        <ItemTemplate>
                        <asp:Label ID="lblContract" runat="server" ForeColor="blue" Text='<%# Bind("ContractNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Qty.">
                        <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" ForeColor="blue" Text='<%# Bind("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Mode">
                        <ItemTemplate>
                         <asp:DropDownList ID="ddlMode"  ForeColor="blue" runat="server" style="width: 100%;">
                        </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Ex-Factory">
                        <ItemTemplate>
                        <asp:Label ID="lblExFactory" ForeColor="blue" runat="server" Text='<%# Bind("ExFactory") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Weeks To Ex">
                        <ItemTemplate>
                        <asp:Label ID="lblWeeksEx" ForeColor="blue" runat="server" Text='<%# Bind("WeekToEx") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DC">
                        <ItemTemplate>
                        <asp:TextBox ID="txtDc" ForeColor="blue" runat="server" Text='<%# Bind("DC") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Weeks To Dc">
                        <ItemTemplate>
                        <asp:Label ID="lblWeeksDc" ForeColor="blue" runat="server" Text='<%# Bind("WeeksToDC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table style="max-width: 100%; width: 100%" border="0" cellpadding="0" cellspacing="0"
                        class="CommoAdmin_Table">
                        <th style="width:80px">
                        Line Item
                    </th>
                    <th style="width:50px">
                        Dest. Code
                    </th>
                    <th style="width:80px">
                        Contact No.
                    </th>
                    <th style="width:50px">
                        Qty.
                    </th>
                    <th style="width:100px">
                        Mode
                    </th>
                    <th style="width:60px">
                        Ex-Factory
                    </th>
                    <th style="width:40px">
                        Weeks To Ex
                    </th>
                    <th style="width:60px">
                        DC
                    </th>
                    <th style="width:40px">
                        Weeks To Dc
                    </th>
                        <tr>
                            <td colspan="10">
                                <img src="../../images/sorry.png" alt="No record found" class="ImgCenter">
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
           <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbutton" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
