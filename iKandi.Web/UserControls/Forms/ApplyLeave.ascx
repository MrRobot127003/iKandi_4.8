<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplyLeave.ascx.cs"
    Inherits="iKandi.Web.ApplyLeave" %>
<asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Cancellation
        </div>
        <div class="text-content">
            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
            <br />
            <a id="A1" runat="server" href="~/Internal/Leave/Leaves.aspx">Click here</a> to
            Holidays List.</div>
    </div>
</asp:Panel>
<asp:Panel ID="pnlSuccessMessage" runat="server" Visible="false">
    <div class="form_box">
        <div class="form_heading">
            Confirmation
        </div>
        <div class="text-content">
            Applied Holiday have been saved into the system successfully!
            <br />
            <a id="A2" href="~/Internal/Leave/Leaves.aspx" runat="server">Click here</a> to
            Holidays List.</div>
    </div>
</asp:Panel>
<asp:Panel ID="pnlForm" runat="server">

    <script type="text/javascript">
        var hdnStartDateClientID = '<%=tbFrom.ClientID %>';
        var hdnEndDateClientID = '<%=tbTo.ClientID %>';
        var fromSessionClientID = '<%=ddlFromSession.ClientID %>';
        var toSessionClientID = '<%=ddlToSession.ClientID %>';
        var daysClientID = '<%=lblDays.ClientID %>';
        $(function() {

            $("#" + hdnStartDateClientID).datepicker({
                dateFormat: "dd M y (D)",
                onSelect: function(dateText, inst) {

                    var fromDate = ParseDateToSimpleDate(dateText);
                    var toDate = ParseDateToSimpleDate($("#<%=tbTo.ClientID %>").val());

                    if (fromDate <= toDate)
                        DoForcePostBack();
                }
            });

            $("#" + hdnEndDateClientID).datepicker({
                dateFormat: "dd M y (D)",
                onSelect: function(dateText, inst) {

                    var toDate = ParseDateToSimpleDate(dateText);
                    var fromDate = ParseDateToSimpleDate($("#<%=tbFrom.ClientID %>").val());

                    if (fromDate <= toDate)
                        DoForcePostBack();
                }
            });
        });

    </script>

    <div class="form_box">
        <div class="form_heading">
            Apply For Holiday <span class="form_small_text">(* Please fill all required fields)</span>
        </div>
        <div>
            <table cellspacing="15" width="100%">
                <tr>
                   <td>                  
                        <span class="hide_me">
                            <asp:DropDownList ID="ddlLeaveType" runat="server" AppendDataBoundItems="true" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlLeaveType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        From*:
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="tbFrom" CssClass="" runat="server" MaxLength="45" AutoPostBack="True"
                            OnTextChanged="tbFrom_TextChanged"></asp:TextBox>
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfvFrom" runat="server" Display="Dynamic" ControlToValidate="tbFrom"
                                ErrorMessage="From is required"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFromSession" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFromSession_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="Session1" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Session2" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td rowspan="2">
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        To*:
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="tbTo" CssClass="" runat="server" MaxLength="45" AutoPostBack="True"
                            OnTextChanged="tbTo_TextChanged"></asp:TextBox>
                        <div class="form_error">
                            <asp:RequiredFieldValidator ID="rfvTo" runat="server" Display="Dynamic" ControlToValidate="tbTo"
                                ErrorMessage="To is required"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlToSession" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlToSession_SelectedIndexChanged">
                            <asp:ListItem Text="Session1" Value="0"></asp:ListItem>
                            <asp:ListItem Selected="True" Text="Session2" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                     <td class="text_align_left font_color_blue">
                        Balance:
                    </td>
                    <td class="text_align_left font_color_blue">
                        <asp:Label ID="lblBalance" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                      <td class=" text_align_left font_color_blue">
                        Number of Holidays Requested:
                    </td>
                    <td class="text_align_left font_color_blue">
                        <asp:Label ID="lblDays" runat="server"></asp:Label>
                        </td>
                </tr>
                
                <tr>
                    <td>
                        Applied To:
                    </td>
                    <td width="30%">
                        <asp:DropDownList ID="ddlAppliedTo" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Reason:
                    </td>
                    <td width="30%" colspan="2">
                        <asp:TextBox ID="tbReason" runat="server" TextMode="MultiLine" Height="100px" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Contact Details:
                    </td>
                    <td width="30%" colspan="2">
                        <asp:TextBox ID="tbContactDetails" runat="server" TextMode="MultiLine" Height="100px"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr class="hide_me">
                    <td>
                        CC:
                    </td>
                    <td width="30%" colspan="2">
                        <asp:TextBox ID="tbCC" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_buttom">
        <asp:Button runat="server" ID="btnSubmit" CssClass="submit" OnClick="Submit_Click" />
    </div>
</asp:Panel>
