<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndPrintCost.ascx.cs" Inherits="iKandi.Web.IndPrintCost" %>


<div class="print_box">
<div class="form_box">
    <div class="form_heading">
       Ind Cost, Print Cost Report
    </div>
    <table width="500px" cellspacing="3">
            <tr>
                <td>
                Purchase Date:
                </td>
                <td>
                    From
                </td>
                <td>
                   <asp:TextBox ID="txtFrom" runat="server" CssClass="date-picker date_style"></asp:TextBox>
                </td>
                <td>
                    To
                </td>
                <td>
                   <asp:TextBox ID="txtTo" runat="server" CssClass="date-picker date_style"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnGo" runat="server" class="go do-not-disable" OnClick="btnGo_click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="form_box">
        <asp:GridView CssClass=" fixed-header item_list" ID="GridView1" runat="server" AutoGenerateColumns="True"
          OnRowCreated="GridView1_OnRowCreated" OnRowDataBound="GridView1_RowDataBound"  >
            <Columns>
            </Columns>
            <EmptyDataTemplate>
                <label>
                    No records Found</label></EmptyDataTemplate>
        </asp:GridView>
    </div>
</div>