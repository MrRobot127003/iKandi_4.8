<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reallocation_History.aspx.cs"
    Inherits="iKandi.Web.Internal.Merchandising.Reallocation_History" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style>
      .EmptxtColor td
      {
         color:Red;
         padding:4px 3px;
       }
    </style>
</head>
<body style="background: #FFFFFF;">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td style="padding-top: 0px;padding:0px 0px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" style="height: 26px; background-color: #405D99; color: #FFFFFF;
                                font-size: 14px; text-align: center; font-family: Lucida Sans Unicode;">
                                Reallocation History Detail
                                 <asp:Button ID="btnClose" runat="server" style="float:right;margin-right:5px;" Text="Close" CssClass="close da_submit_button"
                                    Width="60px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                            </td>
                           <%-- <td style="height: 34px; background-color: #405D99; color: #FFFFFF; font-size: 14px;
                                font-weight: bold; text-transform: uppercase; text-align: right; font-family: Lucida Sans Unicode;">
                                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="close da_submit_button"
                                    Width="86px" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdReallocationHistory" runat="server" AutoGenerateColumns="false"
                                    Width="100%" ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="10px"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF"
                                    HeaderStyle-BackColor="#405D99" CssClass="AddClass_Table" RowStyle-Height="20px" EmptyDataText="There is no history available."
                                    EmptyDataRowStyle-BorderWidth="1px" EmptyDataRowStyle-ForeColor="Red" 
                                    EmptyDataRowStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                    RowStyle-ForeColor="#7E7E7E" ShowFooter="false" 
                                    onrowdatabound="grdReallocationHistory_RowDataBound">
                                    <EmptyDataRowStyle CssClass="EmptxtColor" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblSrNo" runat="server" Font-Size="11px" Text='<%#Eval("SrNo")%>'>'></asp:Label>--%>
                                                <asp:Label ID="lblSrNo" runat="server" Font-Size="11px" Text='<%#Container.DataItemIndex + 1%>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Operation Serial No.(Qty) (Line Number/Contact Number) " ItemStyle-Width="200px">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblOperation" runat="server" Font-Size="11px" Text='<%#Eval("LineNumber")%>'></asp:Label>--%>
                                                <asp:Label ID="lblOperation" runat="server" Font-Size="11px" ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status" ItemStyle-Width="200px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Font-Size="11px" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update Status/Remarks" ItemStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUpdateRemarks" runat="server" Font-Size="11px" Text='<%#Eval("UpdateRemark") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
