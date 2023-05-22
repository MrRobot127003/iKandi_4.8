<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QualityControlHistory.ascx.cs"
    Inherits="iKandi.Web.UserControls.Forms.QualityControlHistory" %>
<div style="width: 100%; vertical-align: top;">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="10" class="da_table_heading_bg_left">
                &nbsp;
            </td>
            <td width="1205" class="da_table_heading_bg">
                <span class="da_h1">Audit History</span>
            </td>
            <td width="13" class="da_table_heading_bg_right">
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="form_box" style="text-align:center;padding:5px" >
        <table id="tblmain" runat="server">
            <tr>
                <td style="text-align: center;">
                    <asp:Label ID="lbl" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                </br>
                <div style="text-align: center;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10" class="da_table_heading_bg_left">
                                &nbsp;
                            </td>
                            <td width="1205" class="da_table_heading_bg">
                                <span class="da_h1">
                                    <asp:Label ID="lblReAuditDate" runat="server"></asp:Label>
                                    <br></br>
                                </span>
                            </td>
                            <td width="13" class="da_table_heading_bg_right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="form_box" style="padding:5px;width:98%;text-align:center" >
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="10" class="da_table_heading_bg_left">
                            &nbsp;
                        </td>
                        <td width="1205" class="da_table_heading_bg">
                            <span class="da_h1">OnLine</span>
                        </td>
                        <td width="13" class="da_table_heading_bg_right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                    <div>
                    <asp:GridView ID="GrdFaultNature" runat="server" Width="100%">
                        <HeaderStyle HorizontalAlign="Center" CssClass="da_table_td" Font-Names="Arial" />
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
                </div>
                
                <div class="form_box" style="padding:5px;width:98%;text-align:center">

                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10" class="da_table_heading_bg_left">
                                &nbsp;
                            </td>
                            <td width="1205" class="da_table_heading_bg">
                                <span class="da_h1">Final Audit </span>
                            </td>
                            <td width="13" class="da_table_heading_bg_right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" class="da_table_border" cellpadding="0" cellspacing="0">
                        <tr align="center" class="da_table_td" style="font: bold 12px/14px arial;">
                            <td>
                                DATE CONDUCTED
                            </td>
                            <td>
                                QTY
                            </td>
                            <td>
                                AQL SAMPLE QTY
                            </td>
                            <td>
                                ACTUAL SAMPLES CHECKED
                            </td>
                            <td colspan="3">
                                QA
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblDataConducted" runat="server" Text='<%# Eval("DateConducted")%>'></asp:Label>
                                <asp:HiddenField ID="HdnFailCount" Value='<%# Eval("FailCount")%>' runat="server" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblQTY" runat="server" Text='<%# Eval("Qty")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblSampleQty" runat="server" Text='<%# Eval("AQLSampleQty")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblSampleChecked" runat="server" Text='<%# Eval("Actual_sample_checked")%>'></asp:Label>
                            </td>
                            <td colspan="3" align="center">
                                <asp:Label ID="lblQA" runat="server" Text='<%# Eval("QA_Name")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="10" class="da_table_heading_bg_left">
                                    &nbsp;
                                </td>
                                <td width="1205" class="da_table_heading_bg">
                                    <span class="da_h1">QUALITY ASSURANCE TO PERFORM SIZE MATRIX </span>
                                </td>
                                <td width="13" class="da_table_heading_bg_right">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="GrdFaultMatrix" ShowHeader="false" runat="server" Width="100%">
                            <HeaderStyle HorizontalAlign="Center" CssClass="da_table_td" Font-Names="Arial" />
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                  

                    <div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="10" class="da_table_heading_bg_left">
                                    &nbsp;
                                </td>
                                <td width="1205" class="da_table_heading_bg">
                                    <span class="da_h1">FAULTS REPORTING </span>
                                </td>
                                <td width="13" class="da_table_heading_bg_right">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="GrdFaultReporing" runat="server" Width="100%" OnRowDataBound="GrdFaultReporing_RowDataBound">
                            <HeaderStyle HorizontalAlign="Center" CssClass="da_table_td" Font-Names="Arial" />
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                    <div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="10" class="da_table_heading_bg_left">
                                    &nbsp;
                                </td>
                                <td width="1205" class="da_table_heading_bg">
                                    <span class="da_h1">FAULTS SUMMARY </span>
                                </td>
                                <td width="13" class="da_table_heading_bg_right">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="GrdFaultSummary" runat="server" Width="100%" OnRowDataBound="GrdFaultSummary_RowDataBound">
                            <HeaderStyle HorizontalAlign="Center" CssClass="da_table_td" Font-Names="Arial" />
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                   </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
