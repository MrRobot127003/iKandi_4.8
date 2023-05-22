<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OB_Operations_HistoryPopUp.aspx.cs"
    Inherits="iKandi.Web.Internal.OrderProcessing.OB_Operations_HistoryPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>History</title>
    <link href="../../css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    span
    {
        text-transform:capitalize;
    }
    .AddClass_Table td:nth-child(2)
    {
        text-align:left;
      }
    </style>
</head>

<body style="background: #FFFFFF;">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td style="padding-top: 0px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="2" align="center" style="height: 26px; background-color: #405D99; color: #FFFFFF;
                                font-size: 14px;text-align: center; 
                                font-family: Lucida Sans Unicode;">
                                Stitching/Manpower History Details
                                  <asp:Button ID="btnClose" runat="server" CssClass="close da_submit_button" style="float:right;margin-right: 2px;" Width="60px" Text="Close" OnClientClick="javascript:self.parent.Shadowbox.close();" />
                            </td>
                           <%-- <td align="right" style="height: 34px; background-color: #405D99; color: #FFFFFF;
                                font-size: 14px; font-weight: bold; text-align: center; text-transform: uppercase;
                                font-family: Lucida Sans Unicode;">
                              
                            </td>--%>
                        </tr>
                        <tr>
                            <td align="center" style="padding-top: 1px;padding:1px 1px; text-transform: none; font-family: Lucida Sans Unicode;">
                                <asp:GridView ID="gvStitchingManpowerDetail" runat="server" AutoGenerateColumns="false"
                                    Width="100%" CssClass="AddClass_Table" ShowHeader="true" HeaderStyle-Height="35px" HeaderStyle-Font-Size="10px"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="false" HeaderStyle-ForeColor="#FFFFFF"
                                    HeaderStyle-BackColor="#405D99" RowStyle-Height="20px" EmptyDataText="There is no history available."
                                    EmptyDataRowStyle-BorderWidth="1px" EmptyDataRowStyle-ForeColor="Red" RowStyle-HorizontalAlign="Center"
                                    RowStyle-ForeColor="#7E7E7E" FooterStyle-ForeColor="#7E7E7E" ShowFooter="false"
                                    FooterStyle-HorizontalAlign="Center">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="SN No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrNo" runat="server" Font-Size="11px" Text='<%#Eval("SrNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="300" HeaderText="Operation Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFactoryWorkForce" runat="server" Text='<%#Eval("FactoryWorkSpace") %>'
                                                    Font-Size="11px"></asp:Label>
                                                <b>&nbsp;(<asp:Label ID="lblWorkerType" runat="server" Text='<%#Eval("WorkerType") %>'
                                                    Font-Size="11px"></asp:Label>)</b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="70px" HeaderText="Machine SAM (Minute)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMachineSAM" runat="server" Font-Size="11px" Text='<%#Eval("StitchSam") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="70px" HeaderText="Machine Cost (₹)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMachineCost" runat="server" Font-Size="11px" Text='<%#Eval("MachineCalc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="Nos.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNos" runat="server" Font-Size="11px" Text='<%#Eval("FinalOB") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Status" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Font-Size="11px" Text='<%#Eval("STATUSNarr") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Update Status/Remarks" ItemStyle-Width="300">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUpdateRemarks" runat="server" Font-Size="11px" Text='<%#Eval("UpdateRemarks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
        </table>
    </div>
    </form>
</body>
</html>
