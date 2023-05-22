<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AverageLeadTimes.ascx.cs"
    Inherits="iKandi.Web.AverageLeadTimes" %>
<div class="form_box">
    <div class="form_heading">
        Average Lead Time
    </div>
    <div>
        <table width="500px" cellspacing="10">
            <tr>
                <td>
                    Client :
                </td>
                <td>
                    <asp:DropDownList ID="ddlClients" runat="server" CssClass="do-not-disable">
                        <asp:ListItem Selected="True" Text="All" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Order Date -
                </td>
                <td>
                    <asp:RadioButtonList ID="radioDate" runat="server" CssClass="do-not-disable" RepeatDirection="Horizontal">
                        <asp:ListItem Text="ExFactory" Selected="true" Value="1"></asp:ListItem>
                        <asp:ListItem Text="DC" Selected="false" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" class="go do-not-disable" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="form_box">
    <asp:GridView ID="grdAvgLeadTimes" runat="server" CssClass="item_list1 fixed-header"
        AutoGenerateColumns="true" OnRowDataBound="grdAvgLeadTimes_RowDataBound" ShowFooter="false"
        OnRowCreated="grdAvgLeadTimes_RowCreated" Width="100%">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <label>
                No records Found
            </label>
        </EmptyDataTemplate>
    </asp:GridView>
</div>
