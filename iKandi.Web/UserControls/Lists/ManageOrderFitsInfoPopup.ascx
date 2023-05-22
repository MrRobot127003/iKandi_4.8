<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageOrderFitsInfoPopup.ascx.cs"
    Inherits="iKandi.Web.ManageOrderFitsInfoPopup" %>
<style type="text/css">
    .style1
    {
        width: 160px;
        text-align:left;
    }
    .ColAlign
    {
        text-align:left;
        padding:0px:
    }
    .style2
    {
        width: 160px;
    }
    .All_Capital
    {
        text-transform:uppercase;
        }
</style>

    <div class="form_heading">
        Fits Tracking
    </div>
    <table id="Table3" runat="server" class="item_list1" style="border-top: 0px; border-bottom: 1px;border-color: Black; width: 650px! important" >
        <tr>
                <td runat="server" id="td2" class="popup_width_style">
                    &nbsp;
                </td>
                <td class="style1">
                    <b>TECHNOLOGIST</b></td>
                <td class="fit_popup_width_style ">
                    <asp:Label ID="lblTech" CssClass="All_Capital" runat="server"></asp:Label>
                </td>
                <td class="fit_popup_width_style " >
                    <b>Production  Merchandiser</b>
                </td>
                <td class="fit_popup_width_style ">
                    <asp:Label ID="lblFitMerchant" CssClass="All_Capital"  runat="server"></asp:Label>
                </td>
        </tr>
    </table>
    <table id="Table2" runat="server" class="item_list1" style="border-top: 0px; border-bottom: 1px;border-color: Black; width: 650px! important">
            <tr>
                <td runat="server" id="td1" class="popup_width_style">
                    &nbsp;&nbsp;
                </td>
                <td class="style1" style="background-color:#edebee; text-align:left;">
                    EVENT&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td class="fit_popup_width_style column_color">
                    TARGET&nbsp;
                </td>
                <td class="fit_popup_width_style " style="background-color:#a5fbfc">
                    PLANNED
                </td>
                <td class="fit_popup_width_style ">
                    ACTUAL
                </td>
            </tr>
            <tr>
                <td runat="server" id="tdSpecsSend" class="popup_width_style">
                    &nbsp;
                </td>
                <td class="style1" style="text-align:left; background-color: #edebee;">
                    SPECS/ SAMPLE SENT
                </td>
                <td class="fit_popup_width_style column_color">
                    <asp:Label ID="lblSpeceSendTarget" runat="server" CssClass="date_style" ></asp:Label>
                </td>
                <td class="fit_popup_width_style font_color_blue" 
                    style="background-color: #a5fbfc">
                    <asp:Label ID="lblSpeceSendplaneddate" runat="server" CssClass="date_style" 
                        Text="NOT PLANNED"></asp:Label>
                </td>
                <td class="fit_popup_width_style font_color_blue">
                    <asp:Label ID="lblSpeceSendActual" runat="server" CssClass="date_style"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView CssClass="item_list1" ID="GridView1" runat="server" AutoGenerateColumns="False"
            Width="650px" OnRowDataBound="GridView1_RowDataBound" ShowHeader="False" BorderWidth="2px" BorderStyle="Solid" BorderColor="Black">
            <Columns >
                <asp:TemplateField ItemStyle-CssClass="" ItemStyle-Width="10px" ShowHeader="false"
                    ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black">
                    <ItemTemplate>
                        &nbsp;
                    </ItemTemplate>
                    <ItemStyle BorderColor="Black" BorderWidth="1px" BorderStyle="Solid" Width="10px">
                    </ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="date_style fit_popup_width_style ColAlign"
                    ShowHeader="false" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" 
                    ItemStyle-BorderColor="Black" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="#EDEBEE">
                    
                    <ItemTemplate>
                        <div style="text-align:left;background-color:#edebee;">
                        <%# (Eval("CommentsSentFor") == DBNull.Value) ? "" : Eval("CommentsSentFor").ToString() %>
                        </div>
                    </ItemTemplate>
                  <ItemStyle BorderColor="Black" BorderWidth="1px" BorderStyle="Solid" CssClass="ColAlign date_style fit_popup_width_style"
                        Width="160px"></ItemStyle>
                    
                   
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="date_style fit_popup_width_style column_color"
                    ShowHeader="false" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid"
                    ItemStyle-BorderColor="Black">
                    <ItemTemplate>
                               <%# (Convert.ToDateTime((Eval("NextPlannedDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("NextPlannedDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("NextPlannedDate"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                    <ItemStyle BorderColor="Black" BorderWidth="1px" BorderStyle="Solid" CssClass="date_style fit_popup_width_style column_color"
                        Width="160px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="date_style fit_popup_width_style font_color_blue"
                    ShowHeader="false" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BackColor="#a5fbfc"
                    ItemStyle-BorderColor="Black">
                    <ItemTemplate>
                        <%--<%# (Convert.ToDateTime((Eval("PlannedDispatchDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("PlannedDispatchDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("PlannedDispatchDate"))).ToString("dd MMM yy (ddd)")%>--%>
                        <%# (((Convert.ToString(Eval("CommentsSentFor"))).Contains("Received"))||(Convert.ToString(Eval("CommentsSentFor"))).Contains("RECEIVED")) ?"NOT PLANNED":((Convert.ToDateTime((Eval("PlannedDispatchDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("PlannedDispatchDate")))) == DateTime.MinValue) ? "NOT PLANNED" : (Convert.ToDateTime(Eval("PlannedDispatchDate"))).ToString("dd MMM yy (ddd)")) %>
                    </ItemTemplate>
                    <ItemStyle BorderColor="Black" BorderWidth="1px" BorderStyle="Solid" CssClass="date_style fit_popup_width_style font_color_blue"
                        Width="160px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="date_style fit_popup_width_style font_color_blue"
                    ShowHeader="false" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid"
                    ItemStyle-BorderColor="Black">
                    <ItemTemplate>
                        <%# (Convert.ToDateTime((Eval("AckDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("AckDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("AckDate"))).ToString("dd MMM yy (ddd)")%>
                    </ItemTemplate>
                    <ItemStyle BorderColor="Black" BorderWidth="1px" BorderStyle="Solid" CssClass="date_style fit_popup_width_style font_color_blue"
                        Width="160px"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table id="tblTopDates" runat="server" class="item_list1" style="border-top: 0px;
            width: 650px! important">
            <tr>
                <td runat="server" id="tdSTC" class="popup_width_style">
                    &nbsp;
                </td>
                <td class="style2"  style="text-align:left; background-color: #edebee;">
                    STC
                </td>
                <td class="fit_popup_width_style column_color">
                    <asp:Label ID="lblSTCTarget" runat="server" CssClass="date_style"></asp:Label>
                </td>
                <td class="fit_popup_width_style font_color_blue" 
                    style="background-color: #a5fbfc">
                    <asp:Label ID="lblSTCplaneddate" runat="server" CssClass="date_style"></asp:Label>
                </td>
                <td class="fit_popup_width_style font_color_blue">
                    <asp:Label ID="lblSTCActual" runat="server" CssClass="date_style"></asp:Label>
                </td>
            </tr>
            <tr id="trTopSentResentRow" runat="server">
                <td runat="server" id="tdTopSent">
                    &nbsp;
                </td>
                <td class="style2"  style="text-align:left; background-color: #edebee;">
                    <asp:Label ID="lblTopSendText" runat="server" ></asp:Label>
                </td>
                <td class="column_color">
                    <asp:Label ID="lbltopsenttgt" runat="server" CssClass="date_style "></asp:Label>
                </td>
                <td class="font_color_blue" style="background-color: #a5fbfc">
                    <asp:Label ID="lbltopplaneddate" runat="server" CssClass="date_style"></asp:Label>
                </td>
                <td class="font_color_blue">
                    <asp:Label ID="lbltopsentact" runat="server" CssClass="date_style"></asp:Label>
                </td>
            </tr>
            <tr id="trTopApprovalRejectionRow">
                <td runat="server" id="tdTopApproval">
                    &nbsp;
                </td>
                <td class="style2"  style="text-align:left; background-color: #edebee;">
                    <asp:Label ID="lblTopApproved" runat="server"></asp:Label>
                </td>
                <td class="column_color">
                    <asp:Label ID="lbltopapptgt" runat="server" CssClass="date_style "></asp:Label>
                </td>
                <td class="font_color_blue" style="background-color: #a5fbfc">
                    <asp:Label ID="lbltopappplaneddate" runat="server" CssClass="date_style"></asp:Label>
                </td>
                <td class="font_color_blue">
                    <asp:Label ID="lbltopappact" runat="server" CssClass="date_style"></asp:Label>
                </td>
            </tr>
        </table>
        <%# (Eval("CommentsSentFor") == DBNull.Value) ? "" : Eval("CommentsSentFor").ToString() %>
        <div class="form_heading">
            Remarks
        </div>
        <table id="Table1" runat="server" class="item_list1" style="border-top: 0px; width: 650px! important">
            <tr>
                <th class="olumn_color " style="width: 275px">
                    ikandi fit Remarks</th>
                <th class="olumn_color " style="width: 275px">
                    Status Meeting Remarks
                </th>
                <th class="olumn_color " style="width: 275px">
                    bipl fit remarks</th>
            </tr>
            <tr>
                <td class="remarks_text remarks_text2" style="width: 275px">
                    <asp:Label runat="server" ID="lblRemarks" CssClass="" ForeColor="Blue" Width="100%"></asp:Label>
                    <br />
                    <asp:HiddenField ID="hdnRemarks" runat="server" Value="" />
                    <asp:HiddenField ID="hdnPermission" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnstyleId" runat="server" Value="" />
                    <asp:HiddenField ID="hdnDeptid" runat="server" Value="0" />
                    <img alt="Sealer Remarks" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                        border="0" onclick="showRemarks('<%= hdnstyleIdBipl.Value  %>','<%= Convert.ToInt32(hdnDeptid.Value)  %>','<%= hdnRemarks.Value  %>' ,'SealerRemarksiKandi','SEALERS_PENDING','<%= Convert.ToInt32(hdnPermission.Value)  %>')" />
                </td>
                <td class="remarks_text remarks_text2" style="width: 275px">
                    <asp:Label runat="server" ID="lblstatusremark" ForeColor="Blue" Width="100%"></asp:Label>
                    <br />
                    <asp:HiddenField ID="hdnstsremark" runat="server" Value="" />
                    <asp:HiddenField ID="hdnstsperm" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnstsstyleid" runat="server" Value="" />
                    <asp:HiddenField ID="hdnstsdepid" runat="server" Value="0" />
                    <img alt="Sealer Remarks" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                        border="0" onclick="showRemarks('<%= hdnstsstyleid.Value  %>','<%= Convert.ToInt32(hdnstsdepid.Value)  %>','<%= hdnstsremark.Value  %>' ,'Status Meeting Remarks','Status_Meeting','<%= Convert.ToInt32(hdnstsperm.Value)  %>')" />
                </td>
                <td class="remarks_text remarks_text2" style="width: 275px">
                    <asp:Label runat="server" ID="lblRemarksBIPL" CssClass="" ForeColor="Blue" Width="100%"></asp:Label>
                    <br />
                    <asp:HiddenField ID="hdnRemarksBipl" runat="server" Value="" />
                    <asp:HiddenField ID="hdnPermissionBipl" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnstyleIdBipl" runat="server" Value="" />
                    <asp:HiddenField ID="hdnDeptidBipl" runat="server" Value="0" />
                    <img alt="Sealer Remarks" title="CLICK TO SEE REMARKS POPUP" src="/App_Themes/ikandi/images/remark.gif"
                        border="0" onclick="showRemarks('<%= hdnstyleIdBipl.Value  %>','<%= Convert.ToInt32(hdnDeptidBipl.Value)  %>','<%= hdnRemarksBipl.Value  %>' ,'SealerRemarksBIPL','SEALERS_PENDING','<%= Convert.ToInt32(hdnPermissionBipl.Value)  %>')" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <a id="fits" target="SealingForm" title="CLICK TO VIEW SEALING FORM" runat="server">
                        FITS FORM</a>
                </td>
            </tr>
        </table>
        <%# (Convert.ToDateTime((Eval("NextPlannedDate") == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(Eval("NextPlannedDate")))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(Eval("NextPlannedDate"))).ToString("dd MMM yy (ddd)")%>
    