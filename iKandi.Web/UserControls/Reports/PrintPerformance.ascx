<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintPerformance.ascx.cs"
    Inherits="iKandi.Web.PrintPerformance" %>
<div class="print_box">
    <div class="form_box">
        <div class="form_heading">
            Print Performance Report
        </div>
        <div>
            <table width="800px" cellspacing="3">
                <tr>
                    <td>
                        Select Duration:                        
                    </td>                   
                    <td>
                        <asp:DropDownList ID="ddlYearSlot" runat="server" CssClass="do-not-disable">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1 Month"></asp:ListItem>
                            <asp:ListItem Value="2" Text="3 Month"></asp:ListItem>
                            <asp:ListItem Value="3" Text="6 Month"></asp:ListItem>
                            <asp:ListItem Value="4" Text="1 Year"></asp:ListItem>
                             <asp:ListItem Value="5" Text="2 Year"></asp:ListItem>
                            <asp:ListItem Value="6" Text="3 Year"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="do-not-disable go" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form_box">
        <asp:GridView CssClass=" fixed-header item_list" ID="GridView1" runat="server" AutoGenerateColumns="True"
            OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_OnRowCreated"
            RowStyle-CssClass="font_color_blue" AlternatingRowStyle-CssClass="font_color_blue">
            <Columns>
            </Columns>
            <EmptyDataTemplate>
                <label>No records Found</label></EmptyDataTemplate>
        </asp:GridView>
    </div>
</div>
